<?php
    $langs = array('de', 'en', 'es', 'fr', 'it', 'ru');
    $oldstrings = array('\u00a9 2013', 'Kabam, Inc.');
	$newstrings = array('\u009a 2015', 'TheRegal, Inc.');
	foreach ($langs as $lang)
	{
	    file_put_contents("../server/app/Languages/$lang.txt", "");
		$file = fopen("../server/app/Languages/$lang.txt", 'w') or die ('rest in piss');
		$link = str_replace($oldstrings, $newstrings, file_get_contents("http://realmofthemadgodhrd.appspot.com/app/getLanguageStrings?languageType=$lang"));
		fwrite($file, $link);
        fclose($file);
	}
?>