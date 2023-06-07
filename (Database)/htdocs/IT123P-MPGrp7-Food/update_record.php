<?php 

include_once('connects.php');

$name = $_GET['name'];
$status =  $_GET['status'];

$result = mysqli_query($con,"UPDATE foodcategory SET status='$status' WHERE name='$name';");
echo "Data Updated";
?>