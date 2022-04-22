using Sat.Recruitment.Core.DTOs;
using Sat.Recruitment.Service.Services;
using Sat.Recruitment.Service.Utils;

namespace Sat.Recruitment.Service.Logic
{
    public class ValidationLogic
    {
        //Validate errors
        internal static string ValidateErrors(UserDTO usr)
        {
            string errors = string.Empty;
            if (usr.Name == null)
                //Validate if Name is null
                errors = "The name is required";
            if (usr.Email == null)
                //Validate if Email is null
                errors = errors + " The email is required";
            if (usr.Address == null)
                //Validate if Address is null
                errors = errors + " The address is required";
            if (usr.Phone == null)
                //Validate if Phone is null
                errors = errors + " The phone is required";

            return errors;
        }

        internal static bool ValidateDuplicity(UserDTO newUser)
        {
            var reader = ReaderService.ReadUsersFromFile();
            List<UserDTO> _users = new List<UserDTO>();
            
            //Normalize email
            var aux = newUser.Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            newUser.Email = string.Join("@", new string[] { aux[0], aux[1] });

            while (reader.Peek() >= 0)
            {
                string[] records = reader.ReadLineAsync().Result.Split(',');
                var user = new UserDTO
                {
                    Name = records[0].ToString(),
                    Email = records[1].ToString(),
                    Phone = records[2].ToString(),
                    Address = records[3].ToString(),
                    UserType = records[4].ToString(),
                    Money = decimal.Parse(records[5].ToString()),
                };
                _users.Add(user);
            }
            reader.Close();

            foreach (var user in _users)
            {
                if (user.Email == newUser.Email || user.Phone == newUser.Phone)
                    return true;
                else if (user.Name == newUser.Name)
                {
                    if (user.Address == newUser.Address)
                        return true;
                }
            }
            return false;
        }
    }
}
