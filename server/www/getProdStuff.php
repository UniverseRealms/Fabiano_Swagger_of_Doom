<?php
    $file = fopen("../MiniGames/Package/" . date('m-d-Y') . ".xml", "w") or die("rip");
    $link = file_get_contents("http://realmofthemadgodhrd.appspot.com/package/getPackages");
	file_put_contents("../MiniGames/Package/" . date('m-d-Y') . ".xml", "");
    fwrite($file, $link);
    fclose($file);

	$file = fopen("../MiniGames/Package/" . date('m-d-Y') . ".json", "w") or die("rip");
    $link = file_get_contents("http://realmofthemadgodhrd.appspot.com/app/globalNews");
	file_put_contents("../MiniGames/Package/" . date('m-d-Y') . ".json", "");
    fwrite($file, $link);
    fclose($file);
	echo '<Success />';
?>