<?php
$json = json_encode($_REQUEST);

$fileSave = fopen("highscore.txt", "a") or die("Can't create highscore.txt");
fclose($fileSave);

$saveString = file_get_contents("highscore.txt");

if ($saveString == "")
  $saveString = "[";
else {
  $saveString = rtrim($saveString, "]");
  $saveString .= ",";
}

$saveString .= $json."]";

$fileSave = fopen("highscore.txt", "w+") or die("Can't create highscore.txt");
fwrite($fileSave, $saveString);
fclose($fileSave);
?>