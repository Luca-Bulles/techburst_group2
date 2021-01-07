import { toolbarOptions, options} from "../js/textEditor.js";


let quill = new Quill("#editor", options);

let editorForm = document.querySelector('#edit');

let editors = {};
editors[editor] = quill;

window.onload = function () {
    let content = document.getElementById("articleContent").value;
    let qEditor = editors[editor];
    render(content, qEditor.root);
    //qEditor.root.innerHTML = content;
};

function getQuillContent() {
    let qEditor = editors[editor];
    let text = qEditor.root.textContent;
    return text;
}

editorForm.onsubmit = function () {
    let content = document.querySelector('input[name=content]');
    content.value = getQuillContent();
}

var render = function (template, node) {
    if (!node) return;
    node.innerHTML = template;
}