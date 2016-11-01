<?php

    $mysql_host = 'localhost';
    $mysql_db = 'pokemon_db';
    $mysql_user = 'root';
    $mysql_pass = 'usbw';

    // create a connection to the database
    $link = mysqli_connect($mysql_host, $mysql_user, $mysql_pass, $mysql_db);

    // if something went wrong, display error information
    if (!$link) {
        echo "Error: Unable to connect to MySQL." . PHP_EOL;
        echo "Debugging errno: " . mysqli_connect_errno() . PHP_EOL;
        echo "Debugging error: " . mysqli_connect_error() . PHP_EOL;
        exit;
    }

		function connectToDB(){
		$db = new PDO("mysql:host=127.0.0.1;dbname=projectcms;port=3307", 'cms', 'Studentje1');
		return $db;
	}
	
session_start();

		//members    		= pokemon
		//projects   		= users
		//project_members   = user_pokemon
		
		
		// lees de tabel, haal ook namen op voor de klus, de corveeer, en de controleur  
		$sql = "SELECT 
					pokemon_ID,					
					users.Username, 
					pokemon.Naam
				FROM 
					user_pokemon
				LEFT OUTER JOIN
					users
				ON 
					user_pokemon.user_ID = users.users_ID
				LEFT OUTER JOIN 
					pokemon
				ON 
					user_pokemon.pokemon_ID = pokemon.pokemons_ID";
					
				//WHERE project_id IN ('1')";
				
// "Select * from project_members where project_id NOT IN ('')";
		
		// voer de query uit
		$result = $link->query($sql);		
		
		// als er iets fout ging met de query, dan heeft $result de waarde false. Geef dan een foutmelding weer.
		if( $result == false ){
			die('There was an error running the query [' . $link->error . ']');
		}

		
		// start een tabel met dikgedrukte kop
		echo '<table>'; 
?>
		
<colgroup>
	<col style="width: 20%">
	<col style="width: 20%">
</colgroup> 

<?php
		echo '<tr>

				<th>Gebruiker</th>
				<th>Pokemon</th>
			</tr>';

		// print de rijen
		while($row = $result->fetch_assoc()){
			
			echo '<tr>';

			echo '<td>' . $row['Username'] . '</td>';
			echo '<td>' . $row['Naam'] . '</td>';
			echo '<td>' ;
			echo '</td>';
			echo '</tr>';	
		}		
		
		// sluit de tabel
		echo '</table>';
		
?>

<colgroup>
	<col style="width: 5%">
	<col style="width: 20%">
	<col style="width: 20%">
</colgroup> 

</div>

<table>

</table>

</body>

</html>