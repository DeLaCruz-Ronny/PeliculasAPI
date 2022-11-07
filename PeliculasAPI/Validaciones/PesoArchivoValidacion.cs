using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.Validaciones
{
    public class PesoArchivoValidacion : ValidationAttribute
    {
        private readonly int pesoMaximoenMegabytes;

        public PesoArchivoValidacion(int PesoMaximoenMegabytes)
        {
            pesoMaximoenMegabytes = PesoMaximoenMegabytes;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile formFile = value as IFormFile;

            if (formFile == null)
            {
                return ValidationResult.Success;
            }

            if (formFile.Length > pesoMaximoenMegabytes * 1024 * 1024) 
            {
                return new ValidationResult($"El peso del archivo no puede ser mayor a {pesoMaximoenMegabytes} mb");
            }

            return ValidationResult.Success;
        }
    }
}
