<?php

$json = file_get_contents("highscore.txt");

$file = json_decode($json, true);


foreach ($file as $data) {
  $dataArray[$data["points"]][0] = $data["points"];
  $dataArray[$data["points"]][1] = $data["name"];
}

arsort($dataArray);

$newDataArray = [];

foreach ($dataArray as $data) {
  array_push($newDataArray, $data);
}

$dataArray = $newDataArray;
$newDataArray = null;

$exportJson = '{"scores": [';

for ($i = 0; $i < 6; $i++) {
  
  $points = $dataArray[$i][0];
  
  if ($points == "")
    $points = "-";
  
  $name = $dataArray[$i][1];
  
  if ($name == "")
    $name = "-";
  
  $exportJson .= '{"points": "'.$points.'", "name": "'.$name.'"},';
}

$exportJson = rtrim($exportJson, ",");

$exportJson .= "]}";

echo $exportJson;

?>