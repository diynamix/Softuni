function rectangle(width, height, color) {
    color = color.replace(color[0], color[0].toUpperCase());

    let rect = { width, height, color, };

    rect.calcArea = () => width * height;

    return rect;
}
