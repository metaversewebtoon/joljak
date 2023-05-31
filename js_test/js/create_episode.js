let count = 0;
let index = 1;
const container = document.getElementById("container");
container.style = "list-style: none";

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
          var episodeContainer = document.createElement("li");
          episodeContainer.className = "episode";
          episodeContainer.style = "border-top: 1px solid #333";

          var episode = document.createElement("a");
          episode.href = "../episode/2-" + index + ".html";
          episode.style = "margin: 10px";

          var thumbnail = document.createElement("div");

          var image = document.createElement("img");
          image.src = URL.createObjectURL(content);
          image.alt = "Image" + (count + 1);
          image.style = "width: 106px; height: 62px";

          // Extract title from image name
          var imageName = zipEntry.name;
          var title = imageName.substring(0, imageName.lastIndexOf("."));
          console.log(title);

          // Create an h2 element for the title
          var titleElement = document.createElement("h3");
          titleElement.textContent = title;
          titleElement.style.marginLeft = "15px"; // Add margin-top to create space

          thumbnail.appendChild(image);
          episode.appendChild(thumbnail);
          episode.appendChild(titleElement);
          episodeContainer.appendChild(episode);
          container.appendChild(episodeContainer);

          count = count + 1;
          index = index + 1;
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
