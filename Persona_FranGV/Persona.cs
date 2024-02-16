namespace Persona_FranGV
{
    public class Persona
    {

        // CONSTANTES

        private const char SEX_DEFAULT_MALE = 'H';
        private const char SEX_DEFAULT_FEMALE = 'F';

        private const int BAJO_PESO = -1;
        private const int IDEAL_PESO = 0;
        private const int SUPERIOR_PESO = 1;


        private const int DNI_MIN = 10000000;
        private const int DNI_MAX = 99999999;


        private const int MAYOR_EDAD = 18;

        // MIEMBROS

        private string _nombre;

        private int _edad;

        private char _sexo;

        private float _peso;

        private float _altura;

        // CONSTRUCTORES

        public Persona()
        {
            _nombre = "";
            _edad = 0;
            _sexo = SEX_DEFAULT_MALE;
            _peso = 0;
            _altura = 0;
            GenerarDniTotal();
        }

        public Persona(string name, int old, char sex)
        {
            Nombre = name;
            Edad = old;
            Sexo = sex;
            _peso= 0;
            _altura = 0;
            GenerarDniTotal();
        }

        public Persona(string name, int old, char sex, float weight, float height)
        {
            Nombre= name;
            Edad = old;
            Sexo = sex;
            Peso = weight;
            Altura = height;
            GenerarDniTotal();
        }
        // PROPIEDADES

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        public int Edad
        {
            get
            {
                return _edad;
            }

            set
            {
                _edad = value;
            }
        }

        public string Dni
        {
            get
            {
                return GenerarDniTotal(); // Solo lectura
            }

        }

        public char Sexo
        {
            get
            {
                return _sexo;
            }

            set
            {
                _sexo = value;
            }
        }

        public float Altura
        {
            get
            {
                return _altura;
            }

            set
            {
                _altura = value;
            }
        }

        public float Peso
        {
            get
            {
                return _peso;
            }
            set
            {
                _peso = value;
            }
        }



        // MÉTODOS PUBLICOS/PRIVADOS


        public float CalcularIMC()
        {
            // RECURSOS

            float IMC = 0;

            // PROCESO

            IMC = Peso / (Altura * Altura);

            // VALIDACION

            if (IMC < 20) IMC = BAJO_PESO; // Peso debajo de lo ideal

            if ((IMC > 20) && (IMC <= 25)) IMC = IDEAL_PESO; // Peso ideal

            if (IMC > 25) IMC = SUPERIOR_PESO;  // Peso encima de lo sano

            // SALIDA

            return IMC;
        }

        public bool EsMayorEdad()
        {
            // RECURSOS

            bool EsMayorEdad = false;

            // PROCESO

            if (Edad > MAYOR_EDAD) EsMayorEdad = true;

            // SALIDA

            return EsMayorEdad;
             
        }

        public static char ComprobarSexo(char sex)
        {
            // RECURSOS

            // PROCESO
            if ((sex != SEX_DEFAULT_MALE) || (sex != SEX_DEFAULT_FEMALE))
            {
                sex = SEX_DEFAULT_MALE;
            }


            // SALIDA
            return sex;

        }
        #region GENERADOR DNI
        /// <summary>
        /// Generar numero para DNI
        /// </summary>
        /// <returns>Numero aleatorio entre 10000000 y 99999999</returns>
        private static string GenerarDniNumeros()
        {
            // RECURSOS

            int NumRamdom = 0;
            string LetraDNI = "";

            // PROCESO

            NumRamdom =  new Random().Next(DNI_MIN, DNI_MAX);

            LetraDNI = Convert.ToString(NumRamdom);

            return LetraDNI;

        } 

        private static char GenerarDniLetra()
        {
            // RECURSOS 

            int ASCII = 0;
            char LETRADNI = ' ';

            // PROCESO

            ASCII = new Random().Next(65, 90); // Genera un número aleatorio entre 65 y 90
                                               // Son los valoresASCII para las letras mayúsculas A - Z

            LETRADNI = (char)ASCII;

            // SALIDA

            return LETRADNI;
        }

        private static string GenerarDniTotal()
        {
            // RECURSOS 

            string cadena = "";

            cadena = GenerarDniNumeros() + GenerarDniLetra();

            return cadena;
             
        }
        #endregion

        public override string ToString()
        {
            // RECURSOS 

            string cadena = "";

            // SALIDA

            if (Sexo == SEX_DEFAULT_MALE) 
            { 
            cadena = $"El paciente {Nombre} de {Edad} años y con DNI {Dni}\n";
            }
            else if (Sexo == SEX_DEFAULT_FEMALE)
            {
                cadena = $"La paciente {Nombre} de {Edad} años y con DNI {Dni}\n";
            }



            cadena += $"Tiene un {Peso}KG y una altura {Altura}M\n";

            // VALIDAR PESO

            if (CalcularIMC() == BAJO_PESO)
            {
                cadena += $"Diagnostico: Está por debajo de su peso ideal.\n";
            }

            if (CalcularIMC() == IDEAL_PESO)
            {
                cadena += $"Diagnostico: Está en su peso ideal.\n";
            }

            if (CalcularIMC() == SUPERIOR_PESO)
            {
                cadena += $"Diagnostico: Está sobrepeso.\n";
            }

            // SALIDA

            return cadena;

           
        }

    }
}
