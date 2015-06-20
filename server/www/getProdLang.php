<?php
    $langs = array("de", "en", "es", "fr", "it", "ru");
    $repOld = array("\u00a9 2013", "Kabam, Inc.");
	$repNew = array("\u009a 2015", "TheRegal, Inc.");
	foreach ($langs as $lang)
	{
	    file_put_contents("../server/app/Languages/" . $lang . ".txt", "");
		$file = fopen("../server/app/Languages/" . $lang . ".txt", "w") or die("rip");
		$link = str_replace($repOld, $repNew, file_get_contents("http://realmofthemadgodhrd.appspot.com/app/getLanguageStrings?languageType=" . $lang));
		fwrite($file, $link);
        fclose($file);
	}
	echo '<Success />';
?>