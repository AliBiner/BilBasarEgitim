<?php


// Düzenleme: Domainhizmetleri.com

use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;
use PHPMailer\PHPMailer\SMTP;

// Gerekli dosyaları include ediyoruz
require 'PHPMailer/PHPMailer.php';
require 'PHPMailer/Exception.php';
require 'PHPMailer/SMTP.php';

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $adSoyad = $_POST["FullName"];
    $email = $_POST["Email"];
    $telefon = $_POST["Phone"];
   //$date = $_POST["Date"];
    //$mesaj = $_POST["Message"];

   /* $message = "Ad ve Soyad: $adSoyad\n";
    $message .= "Email: $email\n";
    $message .= "Telefon: $telefon\n";
    $message .= "Tarih: $date\n";
    $message .= "Mesaj: $mesaj\n";*/

$mail = new PHPMailer(true);

try {
    //SMTP Sunucu Ayarları
    $mail->SMTPDebug = 0;										// DEBUG Kapalı: 0, DEBUG Açık: 2 // Detaylı bilgi için: https://github.com/PHPMailer/PHPMailer/wiki/SMTP-Debugging
    $mail->isSMTP();											// SMTP gönderimi kullan
    $mail->Host       = 'mail.kurumsaleposta.com';					// Email sunucu adresi. Genellikle mail.domainadi.com olarak kullanilir. Bu adresi hizmet saglayiciniza sorabilirsiniz
    $mail->SMTPAuth   = true;									// SMTP kullanici dogrulama kullan
    $mail->Username   = 'system@tmkmuhendislik.com';				// SMTP sunucuda tanimli email adresi
    $mail->Password   = 'CMbc3_2_r@9.fNM6';							// SMTP email sifresi
    $mail->SMTPSecure = PHPMailer::ENCRYPTION_SMTPS;			// SSL icin `PHPMailer::ENCRYPTION_SMTPS` kullanin. SSL olmadan 587 portundan gönderim icin `PHPMailer::ENCRYPTION_STARTTLS` kullanin
    $mail->Port       = 465;									// Eger yukaridaki deger `PHPMailer::ENCRYPTION_SMTPS` ise portu 465 olarak guncelleyin. Yoksa 587 olarak birakin
    $mail->setFrom('system@tmkmuhendislik.com', 'Mehmet KARA'); // Gonderen bilgileri yukaridaki $mail->Username ile aynı deger olmali

    //Alici Ayarları
    $mail->addAddress("ali.bnr.63@gmail.com"); // Alıcı bilgileri
    //$mail->addAddress('mhmmtkara.93@gmail.com');					// İkinci alıcı bilgileri
    //$mail->addReplyTo('YANITADRESI@domainadi.com');			// Alıcı'nın emaili yanıtladığında farklı adrese göndermesini istiyorsaniz aktif edin
    //$mail->addCC('CC@domainadi.com');
    //$mail->addBCC('BCC@domainadi.com');

    // Mail Ekleri
    //$mail->addAttachment('/var/tmp/file.tar.gz');         // Attachment ekleme
    //$mail->addAttachment('/tmp/image.jpg', 'new.jpg');    // Opsiyonel isim degistirerek Attachment ekleme

    // İçerik
    $mail->isHTML(true); // Gönderimi HTML türde olsun istiyorsaniz TRUE ayarlayin. Düz yazı (Plain Text) icin FALSE kullanin
	$mail->CharSet = 'utf-8';
    $mail->Subject = ''. $_POST["Subject"] . ;
   // $mail->Body    = 'Bu bölüm mailin <b>'.$message.'</b> içeriğidir';

   $mail->Body = '<b>Ad ve Soyad: </b>' . $_POST["FullName"] . '<br>';
$mail->Body .= '<b>Email: </b>' . $_POST["Email"] . '<br>';
$mail->Body .= '<b>Telefon: </b>' . $_POST["Phone"] . '<br>';
//$mail->Body .= '<b>Mesaj: </b>' . $_POST["Message"] . '<br>';
//$mail->Body .= 'Tarih: ' . $_POST["Date"] . '<br>';
    $mail->send();
    //echo 'Tebrikler! Email başarıyla gönderildi!';
    echo '<script>alert("Formunuz başarıyla gönderildi.");</script>';
    //$yeni_adres = "/İnsan-Kaynakları";

// Yönlendirme işlemi
header("Refresh: 0; URL=" . /*$yeni_adres*/);
exit; // İşlem sonlandırılır
} catch (Exception $e) {
    echo "Ops! Email iletilemedi. Hata: {$mail->ErrorInfo}";
}

}

?>