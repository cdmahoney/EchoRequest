<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeoLocation.aspx.cs" Inherits="EchoRequest.GeoLocation" %>

<!DOCTYPE html">

<html >
<head runat="server">
    <title>Geolocation tests</title>

	<script src="http://code.jquery.com/jquery-1.8.2.js"></script>

	<script>
	function positionToString(position)
	{
		// "Latitude: " + position.coords.latitude + " Longitude: " + position.coords.longitude + " Timestamp: " + position.timestamp
		var result = JSON.stringify(position);
		return result;
	}
	$(document).ready(function()
	{
		if ("geolocation" in navigator)
		{
			/* geolocation is available */
			
			var positionOptions = {
				"enableHighAccuracy": true,
				"timeout": 10000,
				"maximumAge": Infinity};
			$('#options').text(JSON.stringify(positionOptions));

			// getCurrentPosition
			navigator.geolocation.getCurrentPosition(
				function(position)
				{
					$('#position').text(positionToString(position));
				},
				function(error)
				{
					$('#error').text("getCurrentPosition error: " + JSON.stringify(error));
				},
				positionOptions);
			
			// watchPosition
			var positionsToLog = 100;
			var loggedPositions = 0;
			var watchID = navigator.geolocation.watchPosition(
				function(position) 
				{
					$('<div>').text(positionToString(position)).
						appendTo($('#watchPosition'));
					++loggedPositions;
					if(loggedPositions > positionsToLog)
					{
						navigator.geolocation.clearWatch(watchID);
					}
				},
				function(error)
				{
					$('#error').text("watchPosition error: " + JSON.stringify(error));
				},
				positionOptions);			
			$('<div>').text("Watching position: " + watchID).
				appendTo($('#watchPosition'));
		} 
		else
		{
			$('#error').text("I'm sorry, but geolocation services are not supported by your browser.");
		}
	});
	</script>
</head>
<body>
	<form id="form1" runat="server">
	<h2>Options</h2>
	<div id="options"></div>
	<h2>getPosition</h2>
	<div id="position"></div>
	<h2>watchPosition</h2>
	<div id="watchPosition"></div>
	<h2>Errors</h2>
	<div id="error"></div>
	<h2>References</h2>
	<p>See <a href="http://dev.w3.org/geo/api/spec-source.html" title="Geolocation API Specification">Geolocation API Specification</a></p>
	</form>
</body>
</html>
