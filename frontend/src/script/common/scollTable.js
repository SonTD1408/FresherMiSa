if (document.querySelector(".s-table")){
    document.querySelector(".s-table").addEventListener("scroll",function(event){
        // let thead = document.querySelector(".s-thead");
        if (event.target.scrollLeft > 0){
            console.log(event.target.scrollLeft)
        }
    })
}