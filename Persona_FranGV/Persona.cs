namespace Persona_FranGV
{
    public enum sexo: byte { H, M };

    public class Persona
    {

        // MIEMBROS

        private string _nombre;

        private int _edad;

        private string _dni;

        private float _peso;

        private float _altura;

        // CONSTRUCTORES


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

        // MÉTODOS PUBLICOS/PRIVADOS

    }
}
