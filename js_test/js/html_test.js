let count = 0;
let webtoonIndex = 1;
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
    var htmlContents = []; // Array to store HTML contents
    var urls = []; // Array to store image URLs

    zip.forEach(function (relativePath, zipEntry) {
      if (!zipEntry.dir && zipEntry.name.endsWith(".png")) {
        var promise = zipEntry.async("blob").then(function (content) {
          // Create a container for each image and title
          var episodeContainer = document.createElement("li");
          episodeContainer.className = "episode";
          episodeContainer.style = "border-top: 1px solid #333";

          var episode = document.createElement("a");
          episode.href = "javascript:void(0)";
          episode.style = "margin: 10px";

          var thumbnail = document.createElement("div");

          var image = document.createElement("img");
          image.src = URL.createObjectURL(content);
          image.alt = "Image" + (count + 1);
          image.style = "width: 106px; height: 62px";

          // Extract title from image name
          var imageName = zipEntry.name;
          var title = imageName;
          console.log(title);
          //.substring(0, imageName.lastIndexOf("."));

          // Create an h2 element for the title
          var titleElement = document.createElement("h3");
          titleElement.textContent = title;

          thumbnail.appendChild(image);
          episode.appendChild(thumbnail);
          episode.appendChild(titleElement);
          episodeContainer.appendChild(episode);
          container.appendChild(episodeContainer);

          count = count + 1;

          // Generate HTML content and store in the array
          var htmlContent = `
            <!DOCTYPE html>
            <html lang="en">
              <link rel="stylesheet" href="../../css/webtoon_test.css" />
              <head>
                <meta charset="UTF-8" />
                <meta http-equiv="X-UA-Compatible" content="IE=edge" />
                <meta name="viewport" content="width=device-width, initial-scale=1.0" />
                <title>${webtoonIndex}화</title>
              </head>
              <body>
                <header>
                  <h1>웹툰 뷰어 플랫폼</h1>
                  <nav>
                    <ul>
                      <li><a href="2-2.html">다음화</a></li>
                      <li>
                        <a href="../manhwa/sample_webtoon2.html">회차 목록으로 돌아가기</a>
                      </li>
                      <li><a href="../webtoon_test.html">홈</a></li>
                    </ul>
                  </nav>
                </header>
                <main>
                  <h1 style="text-align: center; margin-bottom: 30px;">${webtoonIndex}화</h1>
                  <div id="image-container">
                    <img src="${image.src}" alt="${image.alt}" />
                  </div>
                </main>
              </body>
            </html>
          `;

          htmlContents.push(htmlContent); // Store HTML content in the array
          urls.push(image.src); // Store image URL in the array
          webtoonIndex = webtoonIndex + 1;
        });

        promises.push(promise);
      }
    });

    return Promise.all(promises).then(function () {
      return { htmlContents: htmlContents, urls: urls };
    });
  })
  .then(function (data) {
    var htmlContents = data.htmlContents;
    var urls = data.urls;

    // Attach click event to each container
    var episodes = document.querySelectorAll(".episode");
    episodes.forEach(function (episode, index) {
      episode.addEventListener("click", function () {
        var newWindow = window.open("", "_self");
        newWindow.document.write(htmlContents[index]);
      });
    });

    console.log("웹툰의 개수 = " + count);
  })
  .catch(function (error) {
    console.error(error);
  });
