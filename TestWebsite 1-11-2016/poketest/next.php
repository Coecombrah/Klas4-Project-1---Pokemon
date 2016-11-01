<?php

    $mysql_host = 'localhost';
    $mysql_db = 'pokemon_db';
    $mysql_user = 'root';
    $mysql_pass = 'usbw';

    // create a connection to the database
//    $link = mysqli_connect($mysql_host, $mysql_user, $mysql_pass, $mysql_db);

    // if something went wrong, display error information
//    if (!$link) {
//        echo "Error: Unable to connect to MySQL." . PHP_EOL;
//        echo "Debugging errno: " . mysqli_connect_errno() . PHP_EOL;
//        echo "Debugging error: " . mysqli_connect_error() . PHP_EOL;
//        exit;
//    }


session_start();		
		
	
	$con =mysql_connect($mysql_host, $mysql_user, $mysql_pass);
	$sdb= mysql_select_db("pokemon_db",$con);
    $sql = "SELECT imageNR, users.Username
			FROM user_pokemon, pokemon, users
			WHERE pokemon.pokemons_ID = user_pokemon.pokemon_ID and users.Username = 12345678";
    $mq = mysql_query($sql) or die ("not working query");
	

	while($row = mysql_fetch_array($mq)){
		echo $row['imageNR'];
		$s=$row['imageNR'];	
		echo '<img src="Images/All_Sprites/'.$s.'.png" alt="HTML5 Icon" style="width:150px;height:150px">';
	}

	//SELECT imageNR, users.Username
	//FROM user_pokemon, pokemon, users
	//WHERE pokemon.pokemon_ID = user_pokemon.pokemon_ID and users.Username = 12345678
?>
	
		

</body>

</html>