namespace ShuffleCaptcha
{
    public class CaptchaReturn
    {
        public string captcha_response { get; set; }
        public bool status { get; set; }
        public string captcha_id { get; set; }

        public CaptchaReturn(string captcharesponse, bool Status, string captchaid)
        {
            captcha_response = captcharesponse;
            status = Status;
            captcha_id = captchaid;
        }

    }
}
