<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mAP.aspx.cs" Inherits="Market_Visit_Portal.mAP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Show/Add multiple markers to Google Maps from database in asp.net website</title>
<style type="text/css">
html { height: 100% }
body { height: 100%; margin: 0; padding: 0 }
#map_canvas { height: 100% }
#mapLegend {
  background: #fdfdfd;
  color: #3c4750;
  padding: 0 10px 0 10px;
  margin: 10px;
  filter: alpha(opacity=80);
  opacity: 0.8;
  border: 1px solid #000;
}
#mapLegend div {
  height: 40px;
  line-height: 25px;
  font-size: 1em;
}
#mapLegend div img {
  float: left;
  height: 30px;
  margin-right: 10px;
}
#mapLegend h2 {
  text-align: center
}
</style>
<script type="text/javascript" src = "https://maps.googleapis.com/maps/api/js?key=AIzaSyDLZ9PJLxbGbu7iICj661k63G1BARWnF0A&sensor=false">
</script>
<script type="text/javascript">
function initialize() {
var markers = JSON.parse('<%=ConvertDataTabletoString() %>');
var mapOptions = {
center: new google.maps.LatLng(markers[0].lat, markers[0].lng),
zoom: 7,
mapTypeId: google.maps.MapTypeId.ROADMAP
//  marker:true
};
var infoWindow = new google.maps.InfoWindow();
//var infoWindowContent=[];
var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);

for (i = 0; i < markers.length; i++) {
    var letter = String.fromCharCode("A".charCodeAt(0) + i - 1);
    var data = markers[i]
    var url = "http://maps.google.com/mapfiles/ms/icons/";
    url += data.color + "-dot.png";
var myLatlng = new google.maps.LatLng(data.lat, data.lng);
var marker = new google.maps.Marker({
position: myLatlng,
map: map,
title: data.title,
icon: {
    url: url
}
});

var infoWindowContent = (
    ('<div class="info_content">' +
    '<h5>' + data.title + '</h3>' +
    '<p>'+data.description+'</p>' +
    '</div>')
);
//var flightPlanCoordinates = [
//new google.maps.LatLng(31.4870778,74.3666282),
//new google.maps.LatLng(32.085235,73.6915042),
//];
//var flightPath = new google.maps.Polyline({
//    path: flightPlanCoordinates,
//    geodesic: true,
//    strokeColor: '#FF0000',
//    strokeOpacity: 1.0,
//    strokeWeight: 2
//});

//flightPath.setMap(map);


(function (marker, data, infoWindowContent) {

    // Attaching a click event to the current marker
    google.maps.event.addListener(marker, "mouseover", function (e) {
        infoWindow.setContent(infoWindowContent);
        infoWindow.open(map, marker);
    });
    google.maps.event.addListener(marker, "mouseout", function (e) {

        infoWindow.close();
    });
})(marker, data, infoWindowContent)
    /* Push Legend to Right Top */
//map.controls(google.maps.ControlPosition.RIGHT_TOP).push(legend);

}
}
</script>
</head>
<body onload="initialize()">
<form id="form1" runat="server">
    
<div id="map_canvas" style="height: 1000px;margin:20px"></div>
  
  
</form>
</body>
</html>