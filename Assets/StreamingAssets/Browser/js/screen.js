// 获取按钮DOM元素
var btnItems = document.querySelectorAll('#screen-btn-list .screen-btn')
// console.log(btnItems)
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
      case '1':
        call_unity("这个是一个精细的模型，3D场景UI始终面向相机")
        break
      case '2':
        open_effect()
        break
      case '3':
        close_effect()
        break
      case '4':
        camera_rotate()
        break
      case '5':
        back()
        break
    }
  })
})

// 点击事件-CALL UNITY
function call_unity() {
  // todo
  console.log('CALL UNITY')
}

// 点击事件-开特效
function open_effect() {
  // todo
  console.log('开特效')
}

// 点击事件-关特效
function close_effect() {
  // todo
  console.log('关特效')
}

// 点击事件-相机自由旋转
function camera_rotate() {
  // todo
  console.log('相机自由旋转')
}

// 点击事件-back
function back() {
  // todo
  console.log('返回')
}