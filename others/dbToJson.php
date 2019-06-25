<?php
  
$username="root";
$password="password";
$database="barcode_database";
  
mysql_connect(localhost,$username,$password);
@mysql_select_db($database) or die( "Unable to select database");
  
$query="SELECT * FROM barcodeLog";
$result=mysql_query($query);
  
$num=mysql_numrows($result);
  
mysql_close();
  
$barcodeValues = array();
  
$i=0;
while ($i < $num)
{
        $dateAndBarcode = array();
        $datetime = mysql_result($result,$i,"datetime");
        $temp = mysql_result($result,$i,"barcode");
  
        $dateAndBarcode["Date"] = $datetime;
        $dateAndBarcode["Barcode"] = $barcode;
  
        $barcodeValues[$i]=$dateAndBarcode;
        $i++;
}
  
echo json_encode($barcodeValues);
  
?>