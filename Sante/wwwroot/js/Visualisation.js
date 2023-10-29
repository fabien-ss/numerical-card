getCoordinatesFromServlet("@IdTerritoire");
var map = L.map('map').setView([-18.972008490174726, 47.54337825241083], 10);
L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    maxZoom: 19,
}).addTo(map);

function getCoordinatesFromServlet(territoryId) {
    const servletURL = 'http://localhost:8080/Foncier-war/Coordinates?IdTerritoire=' + territoryId;

    fetch(servletURL, {
        method: 'GET'
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('La requête a échoué');
            }
            return response.json();
        })
        .then(data => {
            console.log("data =" + data);

            var pointsArray = data.map(function (coord) {
                var [longitude, latitude] = coord.split(' ').map(Number);
                return [latitude, longitude];
            });
            L.polyline(pointsArray, {
                color: 'red'
            }).addTo(map);

            pointsArray.forEach(function (coord) {
                var [latitude, longitude] = coord;
                var marker = L.marker([latitude, longitude]).addTo(map);
                marker.bindPopup("This is a marker.").openPopup();
            });
        })
        .catch(error => {
            console.error('Erreur de la requête :', error);
        });
}
