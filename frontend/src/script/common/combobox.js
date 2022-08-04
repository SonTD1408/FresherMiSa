var buildCombobox = function(){
    let combobox = document.querySelectorAll(".combobox-feild-box");
    // combobox.addEventListener("click",function(){
    //     let comboboxItems = document.querySelector(".combobox-item-box");
    //     if (comboboxItems.style.display=="none"){
    //         document.querySelector(".combobox-item-box").style.display="block";
    //         document.querySelector(".combobox-feild-box").style.border = "1px solid #4262F0";
    //     }else{
    //         comboboxItems.style.display="none";
    //         document.querySelector(".combobox-feild-box").style.border = "1px solid #D3D7DE";
    //     }
    // })
    combobox.forEach(function(combo,index){
        console.log(index)
        combo.addEventListener("click",function(){
            let comboboxItems = combo.querySelector(".combobox-item-box");
            console.log(comboboxItems)
            if (comboboxItems.style.display=="none"){
                comboboxItems.style.display="block";
                comboboxItems.style.border = "1px solid #4262F0";
            }else{
                comboboxItems.style.display="none";
                comboboxItems.style.border = "1px solid #D3D7DE";
            }
        })
    })
}
export default buildCombobox;