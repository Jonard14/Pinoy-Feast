<?php

include_once('connects.php');


$query = "SELECT fooddesc.name, fooddesc.imgfile, fooddesc.description, foodcategory.region, foodrecipe.ingredients, foodrecipe.steps  FROM fooddesc INNER JOIN foodcategory ON fooddesc.name = foodcategory.name INNER JOIN foodrecipe ON foodrecipe.name = foodcategory.name;";
$check=mysqli_query($con,$query);
$row=mysqli_num_rows($check);
$myArray = array();

if($check == FALSE) { 
    echo ".".$row."."; // TODO: better error handling
}

  while($row=mysqli_fetch_array($check))
  	{
  	
	 $myArray[] = $row;
	
  	}
  echo json_encode($myArray);
?>