/*
日期下單選單
供廠商新增頁面使用
 */
;(function($) {
    $.fn.ajbirthday = function(settings) {
        var _defaultSettings = {};
        
        //18 ~ 65 years-old
        var d = new Date();
        var startYear = d.getFullYear() -65  ;
        var endYear = d.getFullYear()  ;
        _defaultSettings.startYear = startYear;
        _defaultSettings.endYear = endYear;
        
        var _settings = $.extend(_defaultSettings, settings);
        var _handler = function() {
            
            //init
            var container = this;
            var selYear = $(".year", container);
            var selMonth = $(".month", container);
            var selDay = $(".day", container);
            var defaultCount = $(".day option", container).length;
                        
            for(;_settings.startYear <= _settings.endYear; _settings.startYear++){
                selYear
                    .append($("<option></option>")
                    .attr("value", _settings.startYear)
                    .text(_settings.startYear));
            }
            
            for(var i = 1; i <= 12; i++){
                selMonth
                    .append($("<option></option>")
                    .attr("value", i)
                    .text(i));
            }
            
            selYear.bind("change", dateChange);
            selMonth.bind("change", dateChange);
            
            function dateChange(){
                var dayCount = new Date(selYear.val(), selMonth.val(), 0).getDate();                
                selDay.children("option:gt(" + defaultCount + ")").remove();
                selDay.children("option:eq(" + defaultCount + ")").remove();
                
                for(var i = 1; i <= dayCount; i++){
                    selDay
                        .append($("<option></option>")
                        .attr("value", i)
                        .text(i));
                }
            }
            
            //default selected(year)
            if(_settings.year){
                $("option[value=" + _settings.year + "]", selYear).prop('selected', true);
            }
            
            //default selected(month)
            if(_settings.month){
                $("option[value=" + _settings.month + "]", selMonth).prop('selected', true);
            }
            
            dateChange();
            
            //default selected(day)
            if(_settings.day){
                $("option[value=" + _settings.day + "]", selDay).prop('selected', true);
            }
        };
        return this.each(_handler);
    };
})(jQuery);