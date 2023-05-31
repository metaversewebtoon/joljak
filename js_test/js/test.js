/*
html에 
<script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.6.0/jszip.min.js"></script>
반드시 추가!!
*/

let count = 0;

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

          // Extract title from image name
          var imageName = zipEntry.name;
          var title = imageName.substring(0, imageName.lastIndexOf("."));

          // Create a container for the image and title
          var container = document.createElement("div");

          // Create a paragraph element for the title
          var titleElement = document.createElement("p");
          titleElement.textContent = title;

          // Append image and title to the container
          container.appendChild(img);
          container.appendChild(titleElement);

          // Append container to the body or any other container
          document.body.appendChild(container);

          count = count + 1;
        });
        promises.push(promise);
      }
    });

    return Promise.all(promises);
  })
  .then(function () {
    console.log("웹툰의 개수 = " + count);
  })
  .catch(function (error) {
    console.error(error);
  });
