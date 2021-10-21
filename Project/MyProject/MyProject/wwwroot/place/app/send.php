<?php
$recipient = "12dashka34@gmail.com";
$site_name = "повідомлення з сайту Consult Group";
$name = trim($_POST["Username"]);
$email = trim($_POST["email"]);
$phone = trim($_POST["phone"]);
$description = trim($_POST["description"]);
$message = "Ім'я: $name \n\n email: $email \n\n phone: $phone \n\n коммент: $description";
$page_title = " Нова заявка з сайту\"Consult Group\"";
    mail($recipient, $page_title, $message, "Content-type: text/plain; charset=\"utf-8\"\n From: $email");
echo "<script>window.location.href = '/'</script>";