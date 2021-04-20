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
}