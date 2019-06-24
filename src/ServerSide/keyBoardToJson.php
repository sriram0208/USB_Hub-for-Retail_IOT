<?php
 
$servername = "localhost";
$username="root";
$password="";
$database="temp_database";
 
// Create connection
$conn = new mysqli($servername, $username, $password, $database);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 

$query="SELECT * FROM tempLog";
$result=$conn->query($query);
  
$conn->close();
 
$tempValues = array();
 
$i=0;
while ($row = $result->fetch_assoc())
{
        $dateAndTemps = array();
        $datetime=$row["date"];
        $temp=$row["temperature"];
 
        $dateAndTemps["Date"] = $datetime;
        $dateAndTemps["Temp"] = $temp;
 
        $tempValues[$i]=$dateAndTemps;
        $i++;
}
 
$res=json_encode($tempValues);
echo $res;
?>