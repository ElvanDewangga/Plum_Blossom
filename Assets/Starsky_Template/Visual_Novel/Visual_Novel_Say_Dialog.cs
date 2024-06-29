// This code is part of the Fungus library (https://github.com/snozbot/fungus)
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
namespace Fungus
{
    /// <summary>
    /// Display story text in a visual novel style dialog box.
    /// </summary>
    public class Visual_Novel_Say_Dialog : MonoBehaviour
    {
        [SerializeField] protected float fadeDuration = 0.25f;
        [Tooltip("The story text UI object")]
        [SerializeField] protected TMP_Text storyText;
        [Tooltip("TextAdapter will search for appropriate output on this GameObject if storyText is null")]
        [SerializeField] protected GameObject storyTextGO;
        bool closeOtherDialogs;
        protected TextAdapter storyTextAdapter = new TextAdapter();
        public virtual string StoryText
        {
            get
            {
                return storyTextAdapter.Text;
            }
            set
            {
                storyTextAdapter.Text = value;
            }
        }
        public virtual RectTransform StoryTextRectTrans
        {
            get
            {
                return storyText != null ? storyText.rectTransform : storyTextGO.GetComponent<RectTransform>();
            }
        }


        protected WriterAudio writerAudio;
        protected Writer writer;
        protected CanvasGroup canvasGroup;

        protected bool fadeWhenDone = true;
        protected float targetAlpha = 0f;
        protected float fadeCoolDownTimer = 0f;

		// Cache active Say Dialogs to avoid expensive scene search
		protected static List<SayDialog> activeSayDialogs = new List<SayDialog>();

		protected virtual void Awake()
		{
            /*
			if (!activeSayDialogs.Contains(this))
			{
				activeSayDialogs.Add(this);
			}
            */
           // nameTextAdapter.InitFromGameObject(nameText != null ? nameText.gameObject : nameTextGO);
            storyTextAdapter.InitFromGameObject(storyText != null ? storyText.gameObject : storyTextGO);
        }

		protected virtual void OnDestroy()
		{
			// activeSayDialogs.Remove(this);
		}
			
		protected virtual Writer GetWriter()
        {
            if (writer != null)
            {
                return writer;
            }

            writer = GetComponent<Writer>();
            if (writer == null)
            {
                writer = gameObject.AddComponent<Writer>();
            }

            return writer;
        }

        protected virtual CanvasGroup GetCanvasGroup()
        {
            if (canvasGroup != null)
            {
                return canvasGroup;
            }
            
            canvasGroup = GetComponent<CanvasGroup>();
            if (canvasGroup == null)
            {
                canvasGroup = gameObject.AddComponent<CanvasGroup>();
            }
            
            return canvasGroup;
        }

        protected virtual WriterAudio GetWriterAudio()
        {
            if (writerAudio != null)
            {
                return writerAudio;
            }
            
            writerAudio = GetComponent<WriterAudio>();
            if (writerAudio == null)
            {
                writerAudio = gameObject.AddComponent<WriterAudio>();
            }
            
            return writerAudio;
        }

        protected virtual void LateUpdate()
        {
            UpdateAlpha();

        }

        protected virtual void UpdateAlpha()
        {
            if (GetWriter().IsWriting)
            {
                targetAlpha = 1f;
                fadeCoolDownTimer = 0.1f;
            }
            else if (fadeWhenDone && Mathf.Approximately(fadeCoolDownTimer, 0f))
            {
                targetAlpha = 0f;
            }
            else
            {
                // Add a short delay before we start fading in case there's another Say command in the next frame or two.
                // This avoids a noticeable flicker between consecutive Say commands.
                fadeCoolDownTimer = Mathf.Max(0f, fadeCoolDownTimer - Time.deltaTime);
            }

            CanvasGroup canvasGroup = GetCanvasGroup();
            if (fadeDuration <= 0f)
            {
                canvasGroup.alpha = targetAlpha;
            }
            else
            {
                float delta = (1f / fadeDuration) * Time.deltaTime;
                float alpha = Mathf.MoveTowards(canvasGroup.alpha, targetAlpha, delta);
                canvasGroup.alpha = alpha;

                if (alpha <= 0f)
                {                   
                    // Deactivate dialog object once invisible
                    gameObject.SetActive(false);
                }
            }
        }

        protected virtual void ClearStoryText()
        {
            StoryText = "";
        }

        #region Public members

        /// <summary>
        /// Currently active Say Dialog used to display Say text
        /// </summary>
        public static SayDialog ActiveSayDialog { get; set; }

        
        /// <summary>
        /// Returns a SayDialog by searching for one in the scene or creating one if none exists.
        /// </summary>
       


        /// <summary>
        /// Write a line of story text to the Say Dialog. Starts coroutine automatically.
        /// </summary>
        /// <param name="text">The text to display.</param>
        /// <param name="clearPrevious">Clear any previous text in the Say Dialog.</param>
        /// <param name="waitForInput">Wait for player input before continuing once text is written.</param>
        /// <param name="fadeWhenDone">Fade out the Say Dialog when writing and player input has finished.</param>
        /// <param name="stopVoiceover">Stop any existing voiceover audio before writing starts.</param>
        /// <param name="voiceOverClip">Voice over audio clip to play.</param>
        /// <param name="onComplete">Callback to execute when writing and player input have finished.</param>
        public virtual void Say(string text, bool clearPrevious, bool waitForInput, bool fadeWhenDone, bool stopVoiceover, bool waitForVO, AudioClip voiceOverClip, Action onComplete)
        {
            StartCoroutine(DoSay(text, clearPrevious, waitForInput, fadeWhenDone, stopVoiceover, waitForVO, voiceOverClip, onComplete));
        }

        /// <summary>
        /// Write a line of story text to the Say Dialog. Must be started as a coroutine.
        /// </summary>
        /// <param name="text">The text to display.</param>
        /// <param name="clearPrevious">Clear any previous text in the Say Dialog.</param>
        /// <param name="waitForInput">Wait for player input before continuing once text is written.</param>
        /// <param name="fadeWhenDone">Fade out the Say Dialog when writing and player input has finished.</param>
        /// <param name="stopVoiceover">Stop any existing voiceover audio before writing starts.</param>
        /// <param name="voiceOverClip">Voice over audio clip to play.</param>
        /// <param name="onComplete">Callback to execute when writing and player input have finished.</param>
        public virtual IEnumerator DoSay(string text, bool clearPrevious, bool waitForInput, bool fadeWhenDone, bool stopVoiceover, bool waitForVO, AudioClip voiceOverClip, Action onComplete)
        {
            var writer = GetWriter();

            if (writer.IsWriting || writer.IsWaitingForInput)
            {
                writer.Stop();
                while (writer.IsWriting || writer.IsWaitingForInput)
                {
                    yield return null;
                }
            }

            if (closeOtherDialogs)
            {
                for (int i = 0; i < activeSayDialogs.Count; i++)
                {
                    var sd = activeSayDialogs[i];
                    if (sd.gameObject != gameObject)
                    {
                        sd.SetActive(false);
                    }
                }
            }
            gameObject.SetActive(true);

            this.fadeWhenDone = fadeWhenDone;

            // Voice over clip takes precedence over a character sound effect if provided


            writer.AttachedWriterAudio = writerAudio;

            yield return StartCoroutine(writer.Write(text, clearPrevious, waitForInput, stopVoiceover, waitForVO, null, onComplete));
        }

        /// <summary>
        /// Tell the Say Dialog to fade out once writing and player input have finished.
        /// </summary>
        public virtual bool FadeWhenDone { get {return fadeWhenDone; } set { fadeWhenDone = value; } }

        /// <summary>
        /// Stop the Say Dialog while its writing text.
        /// </summary>
        public virtual void Stop()
        {
            fadeWhenDone = true;
            GetWriter().Stop();
        }

        /// <summary>
        /// Stops writing text and clears the Say Dialog.
        /// </summary>
        public virtual void Clear()
        {
            ClearStoryText();

            // Kill any active write coroutine
            StopAllCoroutines();
        }

        #endregion
    }
}

