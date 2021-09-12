using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Globalization;
using static System.Console;

namespace AssistentePessoalComReconhecimentoDeVoz
{
    class Program
    {
        private static SpeechRecognitionEngine _motorDeReconhecimentoDeFala = null;
        private static SpeechSynthesizer _sintetizadorDeFala = null;

        static void Main(string[] args)
        {
            #region Configuração
            _motorDeReconhecimentoDeFala = new SpeechRecognitionEngine(new CultureInfo("pt-BR"));
            _motorDeReconhecimentoDeFala.SetInputToDefaultAudioDevice();

            _sintetizadorDeFala = new SpeechSynthesizer();
            #endregion


            string[] frases = { "olá", "boa noite", "boa tarde", "tudo bem" };
            Choices conversas = new Choices(frases);
            GrammarBuilder construtorDeConversas = new GrammarBuilder();
            construtorDeConversas.Append(conversas);
            Grammar gramaticaConversas = new Grammar(construtorDeConversas);
            gramaticaConversas.Name = "conversas";


            string[] comandosPossiveis = { "que horas são", "que dia é hoje"};
            Choices comandos = new Choices(comandosPossiveis);
            GrammarBuilder construtorDeComandos = new GrammarBuilder();
            construtorDeComandos.Append(comandos);
            Grammar gramaticaComandos = new Grammar(construtorDeComandos);
            gramaticaComandos.Name = "sistema";


            Write("<============");
            _motorDeReconhecimentoDeFala.LoadGrammar(gramaticaConversas);
            _motorDeReconhecimentoDeFala.LoadGrammar(gramaticaComandos);
            Write("============>");
            _motorDeReconhecimentoDeFala.SpeechRecognized  += Rec;

            _sintetizadorDeFala.SelectVoiceByHints(VoiceGender.Female);
            ReadKey();

            
        }

        }
    }
}
