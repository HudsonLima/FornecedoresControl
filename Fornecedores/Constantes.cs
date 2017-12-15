using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fornecedores
{
    public static class Constantes
    {
        
        public const string sqlCon = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
              @"AttachDbFilename=|DataDirectory|Teste.mdf;
                Integrated Security=True;
                Connect Timeout=30;";

        /* Caso precisar deixar o banco em outro lugar, utilizar o código abaixo:*/

        //public const string sqlCon = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
        //@"AttachDbFilename=C:\Users\Cliente\Documents\Teste.mdf;
        // Integrated Security=True;
        // Connect Timeout=30;";

        public const int OPCAO_INDEX = 1;
        public const int OPCAO_CADASTRO_REGIAO = 2;
        
    }
}