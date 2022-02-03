using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

namespace DefaultNamespace
{
    public class DictationMonitor : MonoBehaviour
    {
        // debug text
        [SerializeField] private Text m_Hypotheses;
        [SerializeField] private Text m_Recognitions;

        /// <summary>
        /// Minimum confidence level for the dictation recognizer's results.
        /// </summary>
        [SerializeField] private ConfidenceLevel confidenceLevel;
        
        private DictationRecognizer m_DictationRecognizer;

        void OnEnable()
        {

            m_DictationRecognizer = new DictationRecognizer(confidenceLevel);

            m_DictationRecognizer.DictationResult += (text, confidence) =>
            {
                Debug.LogFormat("Dictation result: {0}", text);
                m_Recognitions.text += text + "\n";
            };

            m_DictationRecognizer.DictationHypothesis += (text) =>
            {
                Debug.LogFormat("Dictation hypothesis: {0}", text);
                m_Hypotheses.text += text + "\n";
            };

            m_DictationRecognizer.DictationComplete += (completionCause) =>
            {
                if (completionCause != DictationCompletionCause.Complete)
                    Debug.LogErrorFormat("Dictation completed unsuccessfully: {0}.", completionCause);
            };

            m_DictationRecognizer.DictationError += (error, hresult) =>
            {
                Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
            };

            m_DictationRecognizer.Start();
        }

        private void OnDisable()
        {
            m_DictationRecognizer.Stop();
            m_DictationRecognizer.Dispose();
        }
    }
}