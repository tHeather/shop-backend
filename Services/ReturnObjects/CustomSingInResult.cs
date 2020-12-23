namespace shop_backend.Services.ReturnObjects 
{
    public class CustomSignInResult
    {
        public CustomSignInResult(bool isSucceded, AuthData authData)
        {
            IsSucceeded = isSucceded;
            AuthData = authData;
        }

        public CustomSignInResult(bool isSucceeded, string[] error)
        {
            IsSucceeded = isSucceeded;
            Errors = error;
        }

        public bool IsSucceeded { get; set; }
        public string[] Errors { get; set; }
        public AuthData AuthData { get; set; }
    }
}