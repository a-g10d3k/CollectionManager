var layout = d3.layout.cloud();
var maxTags = 25;
fetch('/Collections/GetTags')
    .then((response) => {
        if (!response.ok) return;
        response.json().then(function (data) {
            let tagCount = data.length < maxTags ? data.length : maxTags;
            layout
                .size([$('#tag-cloud-card').width(), $('#tag-cloud-card').height()])
                .words(data.slice(0,maxTags).map((tag, index) => ({
                        text: tag.name,
                        size: 30 - index * 15 / tagCount,
                        color: `hsl(${Math.floor(Math.random() * 360)}, 90%, 50%)`
                    })))
                .rotate(function () { return 0; })
                .padding(5)
                .font("Impact")
                .fontSize(function (d) { return d.size; })
                .on("end", draw);;

            layout.start();
        });
    });

function draw(words) {
    d3.select("#tag-cloud")
        .attr("width", layout.size()[0])
        .attr("height", layout.size()[1])
        .append("g")
        .attr("transform", "translate(" + layout.size()[0] / 2 + "," + layout.size()[1] / 2 + ")")
        .selectAll("text")
        .data(words)
        .enter().append("text")
        .style("font-size", function (d) { return d.size + "px"; })
        .style("font-family", "Impact")
        .style("fill", function (d) { return d.color; })
        .attr("text-anchor", "middle")
        .attr("transform", function (d) {
            return "translate(" + [d.x, d.y] + ")";
        })
        .text(function (d) { return d.text; });
}