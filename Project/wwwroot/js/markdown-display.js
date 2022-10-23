$('.markdown').each(function () {
    let md = new markdownit();
    this.innerHTML = md.render(this.innerHTML);
});
