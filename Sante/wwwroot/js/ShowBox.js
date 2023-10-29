const boxes = document.querySelectorAll('.box');
let currentIndex = 0;

function showNextBox() {
    boxes[currentIndex].classList.remove('show');
    currentIndex = (currentIndex + 1) % boxes.length;
    boxes[currentIndex].classList.add('show');
}