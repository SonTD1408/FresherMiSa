var Resource = {
    // giới tính 
    Gender:[
        {Gender: 0, GenderName: "Nữ"},
        {Gender: 1, GenderName: "Nam"},
        {Gender: 2, GenderName: "Khác"},
    ],

    // dùng chung 
    IsShare:{
        0: "Không dùng chung",
        1: "Dùng chung"
    },

    // trạng thái response
    ResponseStatus: {
        // thành công lấy dữ liệu nhưng null 
        FailOrNull: 0,
        // thành công lấy dữ liệu và nằm ở DataList 
        SuccessDataList: 1,
        // thành công lấy dữ liệu và nằm ở Data 
        SuccessData: 2,
        // bị trùng mã tiềm năng
        PotentialCodeDuplicate: "PotentialCodeDuplicate",
        // thành công lấy data msg
        SuccessMsg: "s",
        // thành công lấy ra data nhưng bị null
        SuccessNullMsg: "sn",
    },

    formatDateTimeToDate : function(dateSrc){
        let date = new Date(dateSrc),
            year = date.getFullYear().toString(),
            month = (date.getMonth() + 1).toString().padStart(2, '0'),
            day = date.getDate().toString().padStart(2, '0');

        return `${year}-${month}-${day}`;
    }
}
export default Resource;