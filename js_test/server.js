const express = require('express');
const cors = require('cors');
const path = require('path');

const app = express();
const port = 8080;


// CORS 설정
app.use(function(req, res, next) {
  res.setHeader('Access-Control-Allow-Origin', 'http://localhost:8080');
  res.setHeader('Access-Control-Allow-Credentials', 'true');
  next();
});

// 정적 파일 디렉토리 설정
app.use(express.static(path.join(__dirname, 'public')));

// main 페이지 라우트
app.get('/', (req, res) => {
  res.sendFile(path.join(__dirname, 'html/main.html'));
});

// login 페이지 라우트
app.get('/login', (req, res) => {
  res.sendFile(path.join(__dirname, 'html/login.html'));
});

// register 페이지 라우트
app.get('/register', (req, res) => {
  res.sendFile(path.join(__dirname, 'html/register.html'));
});

// user-info 페이지 라우트
app.get('/user-info', (req, res) => {
  res.sendFile(path.join(__dirname, 'html/user_info.html'));
});

// webgl 페이지 라우트
app.get('/production', (req, res) => {
  res.sendFile(path.join(__dirname, 'html/webgl.html'));
});

// imageEditor 페이지 라우트
app.get('/imageEditor', (req, res) => {
  // 리다이렉트할 페이지로 이동
  //res.redirect('views/tui.html');
  res.sendFile(path.join(__dirname, 'html/imageEditor.html'));
});

// viewer 페이지 라우트
app.get('/viewer', (req, res) => {
  res.sendFile(path.join(__dirname, 'html/webtoon_test.html'));
});

// manhwa 페이지 라우트
app.get('/webtoon1', (req, res) => {
  res.sendFile(path.join(__dirname, 'html/manhwa/sample_webtoon1.html'));
});
app.get('/webtoon2', (req, res) => {
  res.sendFile(path.join(__dirname, 'html/manhwa/sample_webtoon2.html'));
});

app.listen(port, () => {
  console.log(`Server running at http://localhost:${port}`);
});






