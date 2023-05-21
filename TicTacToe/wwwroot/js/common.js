window.ShowSwal = (player) => {
    Swal.fire({
        title: player + ' to win 👑',
        width: 350,
        padding: '3em',
        color: '#716add',
        backdrop: `
            rgba(0,0,123,0.4)
            url("/images/nyan-cat-nyan.gif")
            left top
            no-repeat
                      `
    })
}
window.ShowTie = () => {
    Swal.fire({
        title: 'Drawn match\n\nStart over',
        width: 350,
        padding: '3em',
        color: '#716add',
        backdrop: `
            rgba(0,0,123,0.4)
            url("/images/crying-tear.gif")
            left top
            no-repeat
                      `
    })
}