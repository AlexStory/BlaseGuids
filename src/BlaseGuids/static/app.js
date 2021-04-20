function copyText(id) {
  var input = document.createElement('textarea')
  input.value = id
  input.style.top = "0";
  input.style.left = "0";
  input.style.position = "fixed";

  document.body.appendChild(input);
  input.select()
  input.setSelectionRange(0, 9999)
  document.execCommand("copy")
  document.body.removeChild(input)
  message("Copied to clipboard.")
}

function message(text) {
  var div = document.createElement('div')
  var deleteButton = document.createElement('button')
  var content = document.createElement('p')
  div.classList.add('notification')
  div.classList.add('app-alert')
  div.classList.add('is-info')
  div.classList.add('is-light')
  deleteButton.classList.add('delete')
  content.innerText = text
  content.classList.add('has-text-centered')
  div.appendChild(deleteButton)
  div.appendChild(content)
  document.body.appendChild(div)

  deleteButton.addEventListener('click', function() {
    document.body.removeChild(div)
  })

  setTimeout(function() {
    deleteButton.click()
  }, 2000)
  
}