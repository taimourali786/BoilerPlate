using BoilerPlateApi.Authentication;

namespace BoilerPlateApi.Util
{
    public class RegistrationUtil
    {
        public static List<string> ValidateRegistrationModel(RegistrationModel model)
        {
            List<string> errors = new List<string>();
            if (model == null )
            {
                errors.Add("Model cannot be null");
            }
            if(string.IsNullOrEmpty(model.FirstName)) 
            {
                errors.Add("First name cannot be null");
            }
            if (string.IsNullOrEmpty(model.LastName))
            {
                errors.Add("Last name cannot be null");
            }
            if (string.IsNullOrEmpty(model.Email))
            {
                errors.Add("Email cannot be null");
            }
            if (model.Email.Contains("@"))
            {
                errors.Add("Invalid Email");
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                errors.Add("Password cannot be null");
            }
            return errors;
        }
    }
}
