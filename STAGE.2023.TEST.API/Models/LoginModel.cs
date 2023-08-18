using Newtonsoft.Json;

namespace STAGE._2023.TEST.API
{
    public class LoginModel
{
        #region Constructor

        public LoginModel()
        {
        }

        #endregion

        #region Properties


        [JsonProperty("Login")]
        public string Login { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }


        #endregion
    }
}
