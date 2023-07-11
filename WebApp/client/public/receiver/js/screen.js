
import { mySendClickEvent } from "./main.js";



// 获取按钮DOM元素

var btnItems = document.querySelectorAll('#screen-btn-list .screen-btn')

btnItems = Array.from(btnItems)
// 按钮绑定事件及CSS
btnItems.forEach(function (item) {
  item.addEventListener('click', function () {
    var val = this.getAttribute('value')

    var activeItem = document.querySelector('.screen-btn-active')
    if (activeItem) {
      activeItem.classList.remove('screen-btn-active')
    }
    this.classList.add('screen-btn-active')

    switch (val) {
      case '0':
        Btn_Click(10);
        break
      case '1':
        Btn_Click(11);
        break
      case '2':
        Btn_Click(12);
        break
      case '3':
        Btn_Click(13);
        break
      case '4':
        Btn_Click(14);
        break
      case '5':
        Btn_Click(15);
        break
    }
  })
})



function Btn_Click(elementId)
{
  mySendClickEvent(elementId);
}

