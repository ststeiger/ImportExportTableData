
using System;


namespace ImportExportTableData
{


    public partial class frmEncryptDecrypt : System.Windows.Forms.Form
    {

        protected string m_Language;


        public frmEncryptDecrypt()
            : this(System.Globalization.CultureInfo.CurrentCulture)
        { } // End Constructor 


        public frmEncryptDecrypt(System.Globalization.CultureInfo culture)
        {
            // culture = new System.Globalization.CultureInfo("en-US");
            this.m_Language = CultureToLanguage(culture);

            InitializeComponent();
        } // End Constructor 


        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            this.txt3DES.Text = DB.Abstraction.Tools.Cryptography.DES.Crypt(this.txtPlainText.Text);
            this.txtAES.Text = DB.Abstraction.Tools.Cryptography.AES.Encrypt(this.txtPlainText.Text);
            this.lblWurdeKopiert.Visible = true;
            System.Windows.Forms.Clipboard.SetText(this.txt3DES.Text);
        } // End Sub btnEncrypt_Click


        private void Form1_Load(object sender, System.EventArgs e)
        {
            // this.cbLanguage.SelectedText = this.m_Language; // WARNING: Sets text selected in the dropdown, not the item by name...
            this.cbLanguage.SelectedItem = this.m_Language;
            this.txtTime.Text = "&no_cache=" + ToUnixTicks().ToString();
        } // End Sub Form1_Load


        public static Int64 ToUnixTicks()
        {
            return ToUnixTicks(DateTime.Now);
        } // End Function ToUnixTicks


        public static Int64 ToUnixTicks(DateTime dt)
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = dt.ToUniversalTime();
            TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);
            return System.Convert.ToInt64(ts.TotalMilliseconds);
        } // End Function ToUnixTicks


        public string CultureToLanguage(System.Globalization.CultureInfo ci)
        {
            string language = ci == null ? "EN" : language = ci.TwoLetterISOLanguageName.ToUpperInvariant();

            switch (language)
            {
                case "DE": return "Deutsch";
                case "EN": return "English";
                case "ES": return "Español";
                case "FR": return "Français";
                case "IT": return "Italiano";
                case "RU": return "Русский";
                case "ZH": return "中文";
            } // End switch (strSprache)

            return "English";
        }


        public void SetLanguage(string language)
        {

            switch (language)
            {
                case "Deutsch":
                    lblSprache.Text = "Sprache";
                    lblKlartext.Text = "Passwort (Klartext)";
                    lbl3DES.Text = "Passwort (TripleDES)";
                    lblAES.Text = "Passwort (AES)";
                    btnEncrypt.Text = "Verschlüsseln";
                    btnDecrypt.Text = "Entschlüsseln";
                    lblWurdeKopiert.Text = "Das Passwort wurde in die Zwischenablage kopiert.";
                    this.Text = "Passwortverschlüsselung";
                    break;
                case "English":
                    lblSprache.Text = "Language";
                    lblKlartext.Text = "Password (Plain Text)";
                    lbl3DES.Text = "Password (TripleDES)";
                    lblAES.Text = "Password (AES)";
                    btnEncrypt.Text = "Encode";
                    btnDecrypt.Text = "Decrypt";
                    lblWurdeKopiert.Text = "The password has been copied to the clipboard.";
                    this.Text = "Password Encryption";
                    break;
                case "Español":
                    lblSprache.Text = "Lengua";
                    lblKlartext.Text = "Contraseña (Texto Legible)";
                    lbl3DES.Text = "Contraseña (TripleDES)";
                    lblAES.Text = "Contraseña (AES)";
                    btnEncrypt.Text = "Cifrar";
                    btnDecrypt.Text = "Descifrar";
                    lblWurdeKopiert.Text = "La contraseña ha sido copiado en el portapapeles.";
                    this.Text = "Cifrado de contraseñas";
                    break;
                case "Français":
                    lblSprache.Text = "Langue";
                    lblKlartext.Text = "Mot de passe (Texte Clair)";
                    lbl3DES.Text = "Mot de passe (TripleDES)";
                    lblAES.Text = "Mot de passe (AES)";
                    btnEncrypt.Text = "Chiffrer";
                    btnDecrypt.Text = "Déchiffrer";
                    lblWurdeKopiert.Text = "Le mot de passe a été copié dans le presse-papiers.";
                    this.Text = "Cryptage de mot de passe";
                    break;
                case "Italiano":
                    lblSprache.Text = "Lingua";
                    lblKlartext.Text = "Parola (Testo Normale)";
                    lbl3DES.Text = "Parola (TripleDES)";
                    lblAES.Text = "Parola (AES)";
                    btnEncrypt.Text = "Cifrare";
                    btnDecrypt.Text = "Decifrare";
                    lblWurdeKopiert.Text = "La password è stata copiata negli appunti.";
                    this.Text = "Password di crittografia";
                    break;
                case "Русский":
                    lblSprache.Text = "Язык";
                    lblKlartext.Text = "Пароль (Простой текст)";
                    lbl3DES.Text = "Пароль (Тройной ДЕС)";
                    lblAES.Text = "Пароль (АЕС)";
                    btnEncrypt.Text = "шифровать";
                    btnDecrypt.Text = "расшифровывать";
                    lblWurdeKopiert.Text = "Пароль был скопирован в буфер обмена.";
                    this.Text = "Шифрование паролей";
                    break;
                case "中文":
                    lblSprache.Text = "語言";
                    lblKlartext.Text = "密碼（純文字）";
                    lbl3DES.Text = "密碼（三 DES）";
                    lblAES.Text = "密碼（AES）";
                    btnEncrypt.Text = "加密";
                    btnDecrypt.Text = "解碼";
                    lblWurdeKopiert.Text = "密碼已被複製到剪貼板。";
                    this.Text = "密碼加密";
                    break;
                default:
                    lblSprache.Text = "Language";
                    lblKlartext.Text = "Password (plain text)";
                    lbl3DES.Text = "Password (TripleDES)";
                    lblAES.Text = "Password (AES)";
                    btnEncrypt.Text = "Encode";
                    btnDecrypt.Text = "Decrypt";
                    lblWurdeKopiert.Text = "The password has been copied to the clipboard.";
                    this.Text = "Password Encryption";
                    break;
            } // End switch (strSprache)

        } // End Sub SetLanguage


        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetLanguage(cbLanguage.SelectedItem.ToString());
        } // End Sub cbLanguage_SelectedIndexChanged 


        private void txtPlainText_TextChanged(object sender, EventArgs e)
        {
            this.btnEncrypt_Click(sender, e);
        } // End Sub txtPlainText_TextChanged 


        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            //txtDecryptedPw.Text = StefanSteiger.Cryptography.DES.GenerateHash("teststring")
            //txtDecryptedPw.Text = StefanSteiger.Cryptography.DES.GenerateKey()

            if (!string.IsNullOrEmpty(txtAES.Text))
            {
                txtDecryptedPw.Text = DB.Abstraction.Tools.Cryptography.AES.DeCrypt(txtAES.Text);
            }
            else if (!string.IsNullOrEmpty(txt3DES.Text))
            {
                txtDecryptedPw.Text = DB.Abstraction.Tools.Cryptography.DES.DeCrypt(txt3DES.Text);
            }
            else
                System.Windows.Forms.MessageBox.Show("No text to decrypt.");
        } // End Sub btnDecrypt_Click


    } // End partial class frmEncryptDecrypt : System.Windows.Forms.Form


} // End Namespace ImportExportTableData
