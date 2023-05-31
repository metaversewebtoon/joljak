let count = 0;
const container = document.getElementById("container");

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
          // Create a container for each image and title
          var imageContainer = document.createElement("a");
          imageContainer.href = "webtoon_test.html";
          imageContainer.className = "image-container";

          // Create an image element
          var img = document.createElement("img");
          img.src = URL.createObjectURL(content);
          img.alt = "Image " + (count + 1);

          // Extract title from image name
          var imageName = zipEntry.name;
          var title = imageName.substring(0, imageName.lastIndexOf("."));

          // Create an h2 element for the title
          var titleElement = document.createElement("h2");
          titleElement.textContent = title;

          // Append image and title to the container
          imageContainer.appendChild(img);
          imageContainer.appendChild(titleElement);

          // Append container to the main container
          container.appendChild(imageContainer);

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
