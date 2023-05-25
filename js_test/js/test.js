/*
html에 
<script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.6.0/jszip.min.js"></script>
반드시 추가!!
*/

fetch("http://34.145.65.5:46351/file_archive")
  .then(function (response) {
    return response.blob();
  })
  .then(function (blob) {
    return JSZip.loadAsync(blob);
  })
  .then(function (zip) {
    var promises = [];

    zip.forEach(function (relativePath, zipEntry) {
      if (!zipEntry.dir && zipEntry.name.endsWith(".png")) {
        var promise = zipEntry.async("blob").then(function (content) {
          // Create an image element
          var img = document.createElement("img");
          img.src = URL.createObjectURL(content);
          document.body.appendChild(img); // Append image to the body or any other container
        });

        promises.push(promise);
      }
    });

    return Promise.all(promises);
  })
  .catch(function (error) {
    console.error(error);
  });
