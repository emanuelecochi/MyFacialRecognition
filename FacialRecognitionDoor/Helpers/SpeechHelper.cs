using System;
using System.Threading.Tasks;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Controls;

namespace FacialRecognitionDoor.Helpers
{
    /// <summary>
    /// Utilizes SpeechSynthesizer to convert text to an audio message played through a XAML MediaElement
    /// </summary>
    class SpeechHelper : IDisposable
    {
        private MediaElement mediaElement;
        private SpeechSynthesizer synthesizer;
        public static string voiceMatchLanguageCode = "it";
        public static string voiceMatchLanguageName = "Elsa";

        /// <summary>
        /// Accepts a MediaElement that should be placed on whichever page user is on when text is read by SpeechHelper.
        /// Initializes SpeechSynthesizer.
        /// </summary>
        public SpeechHelper(MediaElement media)
        {
            mediaElement = media;
            synthesizer = new SpeechSynthesizer();
            InitializeSynthesizer();
        }

        public async Task InitializeSynthesizer()
        {
            if (synthesizer == null)
            {
                synthesizer = new SpeechSynthesizer();
            }

            /*
            // select the language display
            var voices = SpeechSynthesizer.AllVoices;
            foreach (VoiceInformation voice in voices)
            {
                if (voice.Language.Contains(voiceMatchLanguageCode) && voice.DisplayName.Contains(voiceMatchLanguageName))
                {
                    synthesizer.Voice = voice;
                    break;
                }
            }
            */
        }


        /// <summary>
        /// Synthesizes passed through text as audio and plays speech through the MediaElement first sent through.
        /// </summary>
        public async Task Read(string text)
        {
            if (mediaElement != null && synthesizer != null)
            {
                var stream = await synthesizer.SynthesizeTextToStreamAsync(text);
                mediaElement.AutoPlay = true;
                mediaElement.SetSource(stream, stream.ContentType);
                mediaElement.Play();
            }
        }

        /// <summary>
        /// Disposes of IDisposable type SpeechSynthesizer
        /// </summary>
        public void Dispose()
        {
            synthesizer.Dispose();
        }
    }
}
