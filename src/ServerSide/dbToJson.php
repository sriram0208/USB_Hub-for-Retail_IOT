<?php
header("Content-Type: application/json; charset=UTF-8");
$servername = "localhost";
$username = "root";
$password = "password";
$database = "barcode_database";
try {
            // Try Connect to the DB with new MySqli object - Params {hostname, userid, password, dbname}
            $mysqli = new mysqli($servername, $username, $password, $database);
	    $statement = $mysqli->prepare("select * from barcodeLog;");
            $statement->execute(); // Execute the statement.
            $result = $statement->get_result(); // Binds the last executed statement as a result.
	    echo json_encode($result->fetch_all(MYSQLI_ASSOC));
            //echo json_encode(($result->fetch_array())); // Parse to JSON and print.
        } catch (mysqli_sql_exception $e) { // Failed to connect? Lets see the exception details..
            echo "MySQLi Error Code: " . $e->getCode() . "<br />";
            echo "Exception Msg: " . $e->getMessage();
            exit(); // exit and close connection.
        }
        $mysqli->close(); // finally, close the connection
?>