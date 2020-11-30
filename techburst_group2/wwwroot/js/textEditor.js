var toolbarOptions = [
    ['bold', 'italic', 'underline', 'strike'],
    ['blockquote', 'code-block'],
    [{ 'header': 1 }, { 'header': 2 }],
    [{ 'list': 'ordered' }, { 'list': 'bullet' }],
    [{ 'script': 'sub' }, { 'script': 'super' }],
    [{ 'indent': '-1' }, { 'indent': '+1' }],
    [{ 'direction': 'rtl' }],
    [{ 'size': ['small', false, 'large', 'huge'] }],
    ['link', 'image', 'video', 'formula'],
    [{ 'color': [] }, { 'background': [] }],
    [{ 'font': [] }],
    [{ 'align': [] }]
];
var options = {
    debug: 'info',
    modules: {
        toolbar: toolbarOptions
    },
    readOnly: false,
    theme: 'snow'
};
var quill = new Quill('#editor', options);

var form = document.querySelector('#create');
form.onsubmit = function () {
    var content = document.querySelector('input[name=content]');
    content.value = getQuillText();
    alert(content.value);
}

var editors = {};
editors[editor] = quill;

function getQuillText() {
    var quill = editors[editor];
    var text = quill.getText();
    return text;
}