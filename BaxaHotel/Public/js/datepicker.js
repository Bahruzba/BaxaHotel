jQuery.fn.extend({
    mDtp: function () {
        var userCustomId = $(this).attr('id');
        var dtpType = $("#" + userCustomId + " .mhmPickerInput").data('dtp-type');
        var typeNumber = 0;
        switch (dtpType) {
            case 'date':
                typeNumber = 1;
                break;
            case 'time':
                typeNumber = 2;
                break;
            default:
                typeNumber = 3;
                break;
        }
        var mSelectedDate;
        var mSelectedMonth;
        var mSelectedYear;
        var mMonth = ['Yanvar', 'Fevral', 'Mart', 'Aprel', 'May', 'İyun', 'İyul', 'Avqust', 'Sentyabr', 'Oktyabr', 'Noyabr', 'Dekabr'];

        var userInput = $("#" + userCustomId + " .mhmPickerInput");
        var userClass = $(userInput).attr('class');
        var userValue = $(userInput).attr('value');
        var userAllAttrs = '';
        $(userInput).each(function () {
            $.each(this.attributes, function (i, a) {
                userAllAttrs += a.name + "='" + a.value + "' "
            })
        })
        $("#" + userCustomId + " .mhmPickerInput").remove();
        $("#" + userCustomId + "").append("<div class='mPickerInner'><div class='mClicking'><svg xmlns='http://www.w3.org/2000/svg' xmlns: xlink = 'http://www.w3.org/1999/xlink' version = '1.1' id = 'Capa_1' x = '0px' y = '0px' viewBox = '0 0 512 512' style = 'enable-background:new 0 0 512 512;' xml: space = 'preserve' ><g><g><g><circle cx='386' cy='210' r='20' /><path d='M432,40h-26V20c0-11.046-8.954-20-20-20c-11.046,0-20,8.954-20,20v20h-91V20c0-11.046-8.954-20-20-20     c-11.046,0-20,8.954-20,20v20h-90V20c0-11.046-8.954-20-20-20s-20,8.954-20,20v20H80C35.888,40,0,75.888,0,120v312     c0,44.112,35.888,80,80,80h153c11.046,0,20-8.954,20-20c0-11.046-8.954-20-20-20H80c-22.056,0-40-17.944-40-40V120     c0-22.056,17.944-40,40-40h25v20c0,11.046,8.954,20,20,20s20-8.954,20-20V80h90v20c0,11.046,8.954,20,20,20s20-8.954,20-20V80h91     v20c0,11.046,8.954,20,20,20c11.046,0,20-8.954,20-20V80h26c22.056,0,40,17.944,40,40v114c0,11.046,8.954,20,20,20     c11.046,0,20-8.954,20-20V120C512,75.888,476.112,40,432,40z' /><path d='M391,270c-66.72,0-121,54.28-121,121s54.28,121,121,121s121-54.28,121-121S457.72,270,391,270z M391,472     c-44.663,0-81-36.336-81-81s36.337-81,81-81c44.663,0,81,36.336,81,81S435.663,472,391,472z' /><path d='M420,371h-9v-21c0-11.046-8.954-20-20-20c-11.046,0-20,8.954-20,20v41c0,11.046,8.954,20,20,20h29     c11.046,0,20-8.954,20-20C440,379.954,431.046,371,420,371z' /><circle cx='299' cy='210' r='20' /><circle cx='212' cy='297' r='20' /><circle cx='125' cy='210' r='20' /><circle cx='125' cy='297' r='20' /><circle cx='125' cy='384' r='20' /><circle cx='212' cy='384' r='20' /><circle cx='212' cy='210' r='20' /></g></g></g></svg ></div><input " + userAllAttrs + "></div>");
        $("#" + userCustomId + " .mClicking").click(function () {
            $(this).toggleClass("mOpen");
            if ($(this).hasClass("mOpen")) {
                if (typeNumber == 1) {
                    $("#" + userCustomId + "").append("<div class='dtpBlock'><div class='mainBlock'><div class='mHeader'><div class='mLeft'><span></span></div><div class='mDate'><span class='mDateMonth'></span><span class='mDateYear'></span></div><div class='mRight'><span></span></div></div><div class='mBody'><table class='dayTable'><thead><tr><th>B.e</th><th>Ç.a</th><th>Ç</th><th>C.a</th><th>C</th><th>Ş</th><th>B</th></tr></thead><tbody><tr class='firstTr'><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr></tbody></table></div></div><div class='monthBlock mDisplayNone'><div class='mHeader'><div class='mLeft'><span></span></div><div class='mDate'><span class='mDateYear'></span></div><div class='mRight'><span></span></div></div><div class='mBody'><table class='monthTable'><tbody><tr><td data-monthNum='1'>Yan</td><td data-monthNum='2'>Fev</td><td data-monthNum='3'>Mar</td><td data-monthNum='4'>Apr</td></tr><tr><td data-monthNum='5'>May</td><td data-monthNum='6'>İyun</td><td data-monthNum='7'>İyul</td><td data-monthNum='8'>Avq</td></tr><tr><td data-monthNum='9'>Sen</td><td data-monthNum='10'>Okt</td><td data-monthNum='11'>Noy</td><td data-monthNum='12'>Dek</td></tr></tbody></table></div></div><div class='yearBlock mDisplayNone'><div class='mHeader'><div class='mLeft'><span></span></div><div class='mDate' style='pointer-events: none;'><span class='mFirstYear'></span><span>-</span><span class='mLastYear'></span></div><div class='mRight'><span></span></div></div><div class='mBody'><table class='yearTable'><tbody><tr><td></td><td></td><td></td><td></td></tr><tr><td></td><td></td><td></td><td></td></tr><tr><td></td><td></td><td class='mDisable'></td><td class='mDisable'></td></tr></tbody></table></div></div></div>")
                }
                else if (typeNumber == 2) {
                    $("#" + userCustomId + "").append("<div class='dtpBlock'><div class='clockBlock'><table><tbody><tr class='clockUpIcons'><td class='hourUp'><span></span></td><td style='pointer-events: none'></td><td class='minuteUp'><span></span></td></tr><tr class='mainClock'><td class='mainHour'></td><td style='pointer-events: none'>:</td><td class='mainMinute'></td></tr><tr class='clockDownIcons'><td class='hourDown'><span></span></td><td style='pointer-events: none;'></td><td class='minuteDown'><span></span></td></tr></tbody></table><div class='mAccept'><span class='checkmark'><div class='checkmark_stem'></div><div class='checkmark_kick'></div></span></div></div><div class='clockMinuteBlock mDisplayNone'><table><tbody><tr><td>00</td><td>05</td><td>10</td><td>15</td></tr><tr><td>20</td><td>25</td><td>30</td><td>35</td></tr><tr><td>40</td><td>45</td><td>50</td><td>55</td></tr></tbody></table><div class='mAccept'><span class='checkmark'><div class='checkmark_stem'></div><div class='checkmark_kick'></div></span></div></div><div class='clockHourBlock mDisplayNone'><table><tbody><tr><td>00</td><td>01</td><td>02</td><td>03</td></tr><tr><td>04</td><td>05</td><td>06</td><td>07</td></tr><tr><td>08</td><td>09</td><td>10</td><td>11</td></tr><tr><td>12</td><td>13</td><td>14</td><td>15</td></tr><tr><td>16</td><td>17</td><td>18</td><td>19</td></tr><tr><td>20</td><td>21</td><td>22</td><td>23</td></tr></tbody></table><div class='mAccept'><span class='checkmark'><div class='checkmark_stem'></div><div class='checkmark_kick'></div></span></div></div></div>");
                }
                else {
                    $("#" + userCustomId + "").append("<div class='dtpBlock'><div class='mainBlock'><div class='mHeader'><div class='mLeft'><span></span></div><div class='mDate'><span class='mDateMonth'></span><span class='mDateYear'></span></div><div class='mRight'><span></span></div></div><div class='mBody'><table class='dayTable'><thead><tr><th>B.e</th><th>Ç.a</th><th>Ç</th><th>C.a</th><th>C</th><th>Ş</th><th>B</th></tr></thead><tbody><tr class='firstTr'><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr><tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td></tr></tbody></table></div><div class='mClock'><svg xmlns='http://www.w3.org/2000/svg' height='384pt' viewBox='0 0 384 384' width='384pt'><path d='m343.59375 101.039062c-7.953125 3.847657-11.28125 13.417969-7.433594 21.367188 10.511719 21.714844 15.839844 45.121094 15.839844 69.59375 0 88.222656-71.777344 160-160 160s-160-71.777344-160-160 71.777344-160 160-160c36.558594 0 70.902344 11.9375 99.328125 34.519531 6.894531 5.503907 16.976563 4.351563 22.480469-2.566406 5.503906-6.914063 4.351562-16.984375-2.570313-22.480469-33.652343-26.746094-76-41.472656-119.238281-41.472656-105.863281 0-192 86.136719-192 192s86.136719 192 192 192 192-86.136719 192-192c0-29.335938-6.40625-57.449219-19.039062-83.527344-3.839844-7.96875-13.441407-11.289062-21.367188-7.433594zm0 0' /><path d='m192 64c-8.832031 0-16 7.167969-16 16v112c0 8.832031 7.167969 16 16 16h80c8.832031 0 16-7.167969 16-16s-7.167969-16-16-16h-64v-96c0-8.832031-7.167969-16-16-16zm0 0'/></svg></div></div><div class='monthBlock mDisplayNone'><div class='mHeader'><div class='mLeft'><span></span></div><div class='mDate'><span class='mDateYear'></span></div><div class='mRight'><span></span></div></div><div class='mBody'><table class='monthTable'><tbody><tr><td data-monthNum='1'>Yan</td><td data-monthNum='2'>Fev</td><td data-monthNum='3'>Mar</td><td data-monthNum='4'>Apr</td></tr><tr><td data-monthNum='5'>May</td><td data-monthNum='6'>İyun</td><td data-monthNum='7'>İyul</td><td data-monthNum='8'>Avq</td></tr><tr><td data-monthNum='9'>Sen</td><td data-monthNum='10'>Okt</td><td data-monthNum='11'>Noy</td><td data-monthNum='12'>Dek</td></tr></tbody></table></div><div class='mClock'><svg xmlns='http://www.w3.org/2000/svg' height='384pt' viewBox='0 0 384 384' width='384pt'><path d='m343.59375 101.039062c-7.953125 3.847657-11.28125 13.417969-7.433594 21.367188 10.511719 21.714844 15.839844 45.121094 15.839844 69.59375 0 88.222656-71.777344 160-160 160s-160-71.777344-160-160 71.777344-160 160-160c36.558594 0 70.902344 11.9375 99.328125 34.519531 6.894531 5.503907 16.976563 4.351563 22.480469-2.566406 5.503906-6.914063 4.351562-16.984375-2.570313-22.480469-33.652343-26.746094-76-41.472656-119.238281-41.472656-105.863281 0-192 86.136719-192 192s86.136719 192 192 192 192-86.136719 192-192c0-29.335938-6.40625-57.449219-19.039062-83.527344-3.839844-7.96875-13.441407-11.289062-21.367188-7.433594zm0 0' /><path d='m192 64c-8.832031 0-16 7.167969-16 16v112c0 8.832031 7.167969 16 16 16h80c8.832031 0 16-7.167969 16-16s-7.167969-16-16-16h-64v-96c0-8.832031-7.167969-16-16-16zm0 0'/></svg></div></div><div class='yearBlock mDisplayNone'><div class='mHeader'><div class='mLeft'><span></span></div><div class='mDate' style='pointer-events: none;'><span class='mFirstYear'></span><span>-</span><span class='mLastYear'></span></div><div class='mRight'><span></span></div></div><div class='mBody'><table class='yearTable'><tbody><tr><td></td><td></td><td></td><td></td></tr><tr><td></td><td></td><td></td><td></td></tr><tr><td></td><td></td><td class='mDisable'></td><td class='mDisable'></td></tr></tbody></table></div><div class='mClock'><svg xmlns='http://www.w3.org/2000/svg' height='384pt' viewBox='0 0 384 384' width='384pt'><path d='m343.59375 101.039062c-7.953125 3.847657-11.28125 13.417969-7.433594 21.367188 10.511719 21.714844 15.839844 45.121094 15.839844 69.59375 0 88.222656-71.777344 160-160 160s-160-71.777344-160-160 71.777344-160 160-160c36.558594 0 70.902344 11.9375 99.328125 34.519531 6.894531 5.503907 16.976563 4.351563 22.480469-2.566406 5.503906-6.914063 4.351562-16.984375-2.570313-22.480469-33.652343-26.746094-76-41.472656-119.238281-41.472656-105.863281 0-192 86.136719-192 192s86.136719 192 192 192 192-86.136719 192-192c0-29.335938-6.40625-57.449219-19.039062-83.527344-3.839844-7.96875-13.441407-11.289062-21.367188-7.433594zm0 0' /><path d='m192 64c-8.832031 0-16 7.167969-16 16v112c0 8.832031 7.167969 16 16 16h80c8.832031 0 16-7.167969 16-16s-7.167969-16-16-16h-64v-96c0-8.832031-7.167969-16-16-16zm0 0'/></svg></div></div></div>")
                    $("#" + userCustomId + " .dtpBlock").append("<div class='clockBlock mDisplayNone'><table><tbody><tr class='clockUpIcons'><td class='hourUp'><span></span></td><td style='pointer-events: none'></td><td class='minuteUp'><span></span></td></tr><tr class='mainClock'><td class='mainHour'></td><td style='pointer-events: none'>:</td><td class='mainMinute'></td></tr><tr class='clockDownIcons'><td class='hourDown'><span></span></td><td style='pointer-events: none;'></td><td class='minuteDown'><span></span></td></tr></tbody></table><div class='mAccept'><span class='checkmark'><div class='checkmark_stem'></div><div class='checkmark_kick'></div></span></div></div><div class='clockMinuteBlock mDisplayNone'><table><tbody><tr><td>00</td><td>05</td><td>10</td><td>15</td></tr><tr><td>20</td><td>25</td><td>30</td><td>35</td></tr><tr><td>40</td><td>45</td><td>50</td><td>55</td></tr></tbody></table><div class='mAccept'><span class='checkmark'><div class='checkmark_stem'></div><div class='checkmark_kick'></div></span></div></div><div class='clockHourBlock mDisplayNone'><table><tbody><tr><td>00</td><td>01</td><td>02</td><td>03</td></tr><tr><td>04</td><td>05</td><td>06</td><td>07</td></tr><tr><td>08</td><td>09</td><td>10</td><td>11</td></tr><tr><td>12</td><td>13</td><td>14</td><td>15</td></tr><tr><td>16</td><td>17</td><td>18</td><td>19</td></tr><tr><td>20</td><td>21</td><td>22</td><td>23</td></tr></tbody></table><div class='mAccept'><span class='checkmark'><div class='checkmark_stem'></div><div class='checkmark_kick'></div></span></div></div>");
                }
            }
            else {
                $("#" + userCustomId + " .dtpBlock").remove();
            }
            if (typeNumber != 2) {
                $("#" + userCustomId + " .mainBlock .mBody tbody td.mSelected").removeClass("mSelected");
                if ($("#" + userCustomId + " .mhmPickerInput").val() == '') {
                    var nowDate = new Date();
                    var nowMonth = nowDate.getMonth();
                    var nowYear = nowDate.getFullYear();
                    var nowDay = nowDate.getDate();
                    var stringMonth = mMonth[nowMonth];

                    if (typeNumber == 3) {
                        var nowHour = nowDate.getHours();
                        var nowMinute = nowDate.getMinutes();
                        if (nowHour < 9) {
                            nowHour = "0" + nowHour;
                        }
                        if (nowMinute < 9) {
                            nowMinute = "0" + nowMinute;
                        }
                        $("#" + userCustomId + " .clockBlock .mainClock .mainHour").text(nowHour);
                        $("#" + userCustomId + " .clockBlock .mainClock .mainMinute").text(nowMinute);
                    }

                }
                else {
                    if (!inputControl($("#" + userCustomId + " .mhmPickerInput").val())) {
                        $("#" + userCustomId + " .mhmPickerInput").addClass("wrongInput");
                        $("#" + userCustomId + " .mClicking").removeClass("mOpen");
                        $("#" + userCustomId + " .dtpBlock").remove();
                    }
                    else {
                        $("#" + userCustomId + " .mhmPickerInput").removeClass("wrongInput");
                    }
                    var fullInputWithClock = $("#" + userCustomId + " .mhmPickerInput").val().split(" ");
                    var fullInputValUnsplitted = fullInputWithClock[0];
                    fullInputVal = fullInputValUnsplitted.split("-");
                    var nowDay = Number(fullInputVal[2]);
                    var nowMonth = Number(fullInputVal[1]);
                    var nowYear = Number(fullInputVal[0]);
                    nowMonth--;
                    stringMonth = mMonth[nowMonth];

                    if (typeNumber == 3) {
                        $("#" + userCustomId + " .mhmPickerInput").removeClass("wrongInput");
                        var fullInputValueForClock = $("#" + userCustomId + " .mhmPickerInput").val().split(" ");
                        var fullClockValUnsplitted = fullInputValueForClock[1];
                        var clockArray = fullClockValUnsplitted.split(":");
                        var inputValHour = clockArray[0];
                        var inputValMinute = clockArray[1];
                        $("#" + userCustomId + " .clockBlock .mainHour").text(inputValHour);
                        $("#" + userCustomId + " .clockBlock .mainMinute").text(inputValMinute);
                    }

                }
                $("#" + userCustomId + " .mainBlock .mHeader .mDate .mDateMonth").text(stringMonth);
                $("#" + userCustomId + " .mainBlock .mHeader .mDate .mDateYear").text(nowYear);
                var pickerMonth = $("#" + userCustomId + " .mainBlock .mHeader .mDate .mDateMonth").text();
                if (pickerMonth == 'İyul') {
                    pickerMonth = 'iyul';
                }
                else if (pickerMonth == 'İyun') {
                    pickerMonth = 'iyun';
                }
                else {
                    pickerMonth = pickerMonth.toLowerCase();
                }
                var pickerYear = $("#" + userCustomId + " .mainBlock .mHeader .mDate .mDateYear").text().toLowerCase();

                mSelectedDate = nowDay;
                mSelectedMonth = stringMonth;
                mSelectedYear = nowYear;
                fillCalendar(pickerMonth, pickerYear);
            }
            else {
                if (!$("#" + userCustomId + " .mhmPickerInput").val() == '') {
                    if (!inputControl($("#" + userCustomId + " .mhmPickerInput").val())) {
                        $("#" + userCustomId + " .mhmPickerInput").addClass("wrongInput");
                        $("#" + userCustomId + " .mClicking").removeClass("mOpen");
                        $("#" + userCustomId + " .dtpBlock").remove();
                    }
                    else {
                        $("#" + userCustomId + " .mhmPickerInput").removeClass("wrongInput");
                        var fullInputValueForClock = $("#" + userCustomId + " .mhmPickerInput").val().split(" ");
                        var fullClockValUnsplitted = fullInputValueForClock[0];
                        var clockArray = fullClockValUnsplitted.split(":");
                        var inputValHour = clockArray[0];
                        var inputValMinute = clockArray[1];
                        $("#" + userCustomId + " .clockBlock .mainHour").text(inputValHour);
                        $("#" + userCustomId + " .clockBlock .mainMinute").text(inputValMinute);
                    }
                }
                else {
                    $("#" + userCustomId + " .mhmPickerInput").removeClass("wrongInput");
                    var nowDateforClock = new Date();
                    var nowHour = nowDateforClock.getHours();
                    var nowMinute = nowDateforClock.getMinutes();
                    if (nowHour < 9) {
                        nowHour = "0" + nowHour;
                    }
                    if (nowMinute < 9) {
                        nowMinute = "0" + nowMinute;
                    }
                    $("#" + userCustomId + " .clockBlock .mainClock .mainHour").text(nowHour);
                    $("#" + userCustomId + " .clockBlock .mainClock .mainMinute").text(nowMinute);
                }
            }
        });

        $(document).click(function (e) {
            if (!$(e.target).closest(".mClicking").length && !$(e.target).closest(".dtpBlock").length) {
                $("#" + userCustomId + " .mClicking").removeClass("mOpen");
                $("#" + userCustomId + " .dtpBlock").remove();
            }
        });
        $(document).on('click', "#" + userCustomId + " .mainBlock .mHeader .mLeft span", function () {
            $("#" + userCustomId + " .mainBlock .mBody tbody td.mSelected").removeClass("mSelected");
            var month = $("#" + userCustomId + " .mainBlock .mHeader .mDate .mDateMonth").text();
            var year = $("#" + userCustomId + " .mainBlock .mHeader .mDate .mDateYear").text();
            var currentPrev = '';
            switch (month) {
                case 'Yanvar':
                    currentPrev = 'Dekabr';
                    year--;
                    break;
                case 'Fevral':
                    currentPrev = 'Yanvar';
                    break;
                case 'Mart':
                    currentPrev = 'Fevral';
                    break;
                case 'Aprel':
                    currentPrev = 'Mart';
                    break;
                case 'May':
                    currentPrev = 'Aprel';
                    break;
                case 'İyun':
                    currentPrev = 'May';
                    break;
                case 'İyul':
                    currentPrev = 'İyun';
                    break;
                case 'Avqust':
                    currentPrev = 'İyul';
                    break;
                case 'Sentyabr':
                    currentPrev = 'Avqust';
                    break;
                case 'Oktyabr':
                    currentPrev = 'Sentyabr';
                    break;
                case 'Noyabr':
                    currentPrev = 'Oktyabr';
                    break;
                case 'Dekabr':
                    currentPrev = 'Noyabr';
                    break;
            }
            $("#" + userCustomId + " .mainBlock .mHeader .mDate .mDateMonth").text(currentPrev);
            $("#" + userCustomId + " .mainBlock .mHeader .mDate .mDateYear").text(year);

            if (currentPrev == 'İyul') {
                currentPrev = 'iyul';
            }
            else if (currentPrev == 'İyun') {
                currentPrev = 'iyun';
            }
            else {
                currentPrev = currentPrev.toLowerCase();
            }
            fillCalendar(currentPrev, year);
        });

        $(document).on('click', "#" + userCustomId + " .mainBlock .mHeader .mRight span", function () {
            $("#" + userCustomId + " .mainBlock .mBody tbody td.mSelected").removeClass("mSelected");
            var month = $("#" + userCustomId + " .mainBlock .mHeader .mDate .mDateMonth").text();
            var year = $("#" + userCustomId + " .mainBlock .mHeader .mDate .mDateYear").text();
            var currentNext = '';
            console.log(month + year)
            switch (month) {
                case 'Yanvar':
                    currentNext = 'Fevral';
                    break;
                case 'Fevral':
                    currentNext = 'Mart';
                    break;
                case 'Mart':
                    currentNext = 'Aprel';
                    break;
                case 'Aprel':
                    currentNext = 'May';
                    break;
                case 'May':
                    currentNext = 'İyun';
                    break;
                case 'İyun':
                    currentNext = 'İyul';
                    break;
                case 'İyul':
                    currentNext = 'Avqust';
                    break;
                case 'Avqust':
                    currentNext = 'Sentyabr';
                    break;
                case 'Sentyabr':
                    currentNext = 'Oktyabr';
                    break;
                case 'Oktyabr':
                    currentNext = 'Noyabr';
                    break;
                case 'Noyabr':
                    currentNext = 'Dekabr';
                    break;
                case 'Dekabr':
                    currentNext = 'Yanvar';
                    year++;
                    break;
            }
            $("#" + userCustomId + " .mainBlock .mHeader .mDate .mDateMonth").text(currentNext);
            $("#" + userCustomId + " .mainBlock .mHeader .mDate .mDateYear").text(year);
            if (currentNext == 'İyul') {
                currentNext = 'iyul';
            }
            else if (currentNext == 'İyun') {
                currentNext = 'iyun';
            }
            else {
                currentNext = currentNext.toLowerCase();
            }
            fillCalendar(currentNext, year);
        });

        $(document).on('click', "#" + userCustomId + " .mainBlock .mBody tbody td", function () {
            if (typeNumber != 2) {
                $("#" + userCustomId + " .mainBlock .mBody tbody td.mSelected").removeClass("mSelected");
                $(this).addClass("mSelected");
                var nowSelectedDay = $(this).text();
                if ($(this).parents(".firstTr").length && $(this).text() > 7) {
                    var nowSelectedMonth = $("#" + userCustomId + " .mainBlock .mHeader .mDate .mDateMonth").text();
                    var nowSelectedYear = $("#" + userCustomId + " .mainBlock .mHeader .mDate .mDateYear").text();
                    var nowSelectedMonthNumber = jQuery.inArray(nowSelectedMonth, mMonth);
                    if (nowSelectedMonthNumber == 0) {
                        nowSelectedMonthNumber = 12;
                        nowSelectedYear--;
                    }
                }
                else if ($(this).hasClass("mDisable")) {
                    var nowSelectedMonth = $("#" + userCustomId + " .mainBlock .mHeader .mDate .mDateMonth").text();
                    var nowSelectedYear = $("#" + userCustomId + " .mainBlock .mHeader .mDate .mDateYear").text();
                    var nowSelectedMonthNumber = jQuery.inArray(nowSelectedMonth, mMonth);
                    nowSelectedMonthNumber += 2;
                    if (nowSelectedMonthNumber == 13) {
                        nowSelectedMonthNumber = 1;
                        nowSelectedYear++;
                    }
                }
                else {
                    var nowSelectedMonth = $("#" + userCustomId + " .mainBlock .mHeader .mDate .mDateMonth").text();
                    var nowSelectedYear = $("#" + userCustomId + " .mainBlock .mHeader .mDate .mDateYear").text();
                    var nowSelectedMonthNumber = jQuery.inArray(nowSelectedMonth, mMonth);
                    nowSelectedMonthNumber++;
                }
                var inputValueAdd = '';


                inputValueAdd += nowSelectedYear + '-';
                if (nowSelectedMonthNumber == 12 || nowSelectedMonthNumber == 11 || nowSelectedMonthNumber == 10) {
                    inputValueAdd += nowSelectedMonthNumber + "-";
                }
                else {
                    inputValueAdd += "0" + nowSelectedMonthNumber + "-";
                }

                if (nowSelectedDay.length == 1) {
                    inputValueAdd += "0" + nowSelectedDay;
                }
                else {
                    inputValueAdd += nowSelectedDay;
                }

            }

            if (typeNumber != 1) {
                if (typeNumber == 3) {
                    inputValueAdd += " ";
                }
                var clockHourValue = $("#" + userCustomId + " .clockBlock .mainClock .mainHour").text();
                var clockMinuteValue = $("#" + userCustomId + " .clockBlock .mainClock .mainMinute").text();
                inputValueAdd += clockHourValue + ":" + clockMinuteValue;
            }

            $("#" + userCustomId + " .mhmPickerInput").val(inputValueAdd);
            $("#" + userCustomId + " .mainBlock").remove();
        });

        //monthBlock
        $(document).on('click', "#" + userCustomId + " .mainBlock .mHeader .mDate", function () {
            $("#" + userCustomId + " .monthBlock .mBody tbody td.mSelected").removeClass("mSelected");
            $(this).parents(".mainBlock").addClass("mDisplayNone");
            $("#" + userCustomId + " .monthBlock").removeClass("mDisplayNone");
            var currYear = $("#" + userCustomId + " .mainBlock .mHeader .mDate .mDateYear").text();

            if ($("#" + userCustomId + " .mhmPickerInput").val() != '') {
                var currInputWithClock = $("#" + userCustomId + " .mhmPickerInput").val().split(" ");
                var currInput = currInputWithClock[0].split("-");
                var currInputMonth = Number(currInput[1]);
                var currInputYear = currInput[0];
            }
            else {
                var newNowDate = new Date();
                var currInputMonth = newNowDate.getMonth();
                var currInputYear = newNowDate.getFullYear();
                currInputMonth++;
            }

            if (currInputYear == currYear) {
                $("#" + userCustomId + " .monthBlock .mBody tbody td[data-monthNum='" + currInputMonth + "']").addClass("mSelected");
            }
            else {
                $("#" + userCustomId + " .monthBlock .mBody tbody td.mSelected").removeClass("mSelected");
            }
            $("#" + userCustomId + " .monthBlock .mHeader .mDate .mDateYear").text(currYear);
        });
        $(document).on('click', "#" + userCustomId + " .monthBlock .mHeader .mLeft span", function () {
            var monthBlockYear = Number($("#" + userCustomId + " .monthBlock .mHeader .mDate .mDateYear").text());
            monthBlockYear--;
            $("#" + userCustomId + " .monthBlock .mHeader .mDate .mDateYear").text(monthBlockYear);

            var currYear = $("#" + userCustomId + " .monthBlock .mHeader .mDate .mDateYear").text();

            if ($("#" + userCustomId + " .mhmPickerInput").val() != '') {
                var currInputWithClock = $("#" + userCustomId + " .mhmPickerInput").val().split(" ");
                var currInput = currInputWithClock[0].split("-");
                var currInputMonth = Number(currInput[1]);
                var currInputYear = currInput[0];
            }
            else {
                var newNowDate = new Date();
                var currInputMonth = newNowDate.getMonth();
                var currInputYear = newNowDate.getFullYear();
                currInputMonth++;
            }

            if (currInputYear == currYear) {
                $("#" + userCustomId + " .monthBlock .mBody tbody td[data-monthNum='" + currInputMonth + "']").addClass("mSelected");
            }
            else {
                $("#" + userCustomId + " .monthBlock .mBody tbody td.mSelected").removeClass("mSelected");
            }
        })
        $(document).on('click', "#" + userCustomId + " .monthBlock .mHeader .mRight span", function () {
            var monthBlockYear = Number($("#" + userCustomId + " .monthBlock .mHeader .mDate .mDateYear").text());
            monthBlockYear++;
            $("#" + userCustomId + " .monthBlock .mHeader .mDate .mDateYear").text(monthBlockYear);

            var currYear = $("#" + userCustomId + " .monthBlock .mHeader .mDate .mDateYear").text();

            if ($("#" + userCustomId + " .mhmPickerInput").val() != '') {
                var currInputWithClock = $("#" + userCustomId + " .mhmPickerInput").val().split(" ");
                var currInput = currInputWithClock[0].split("-");
                var currInputMonth = Number(currInput[1]);
                var currInputYear = currInput[0];
            }
            else {
                var newNowDate = new Date();
                var currInputMonth = newNowDate.getMonth();
                var currInputYear = newNowDate.getFullYear();
                currInputMonth++;
            }

            if (currInputYear == currYear) {
                $("#" + userCustomId + " .monthBlock .mBody tbody td[data-monthNum='" + currInputMonth + "']").addClass("mSelected");
            }
            else {
                $("#" + userCustomId + " .monthBlock .mBody tbody td.mSelected").removeClass("mSelected");
            }
        })
        $(document).on('click', "#" + userCustomId + " .monthBlock .mBody tbody td", function () {
            var nthChildClicked = $("#" + userCustomId + " .monthBlock .mBody tbody td").index(this);
            var clickedMonth = mMonth[nthChildClicked];
            var clickedYear = $("#" + userCustomId + " .monthBlock .mHeader .mDate .mDateYear").text();
            $("#" + userCustomId + " .monthBlock").addClass("mDisplayNone");
            $("#" + userCustomId + " .mainBlock").removeClass("mDisplayNone");
            $("#" + userCustomId + " .mainBlock .mHeader .mDate .mDateYear").text(clickedYear);
            $("#" + userCustomId + " .mainBlock .mHeader .mDate .mDateMonth").text(clickedMonth);
            if (clickedMonth == 'İyul') {
                clickedMonth = 'Iyul'
            }

            if (clickedMonth == 'İyun') {
                clickedMonth = 'Iyun'
            }
            clickedMonth = clickedMonth.toLocaleLowerCase();

            fillCalendar(clickedMonth, clickedYear);
        });
        // ------------------------------------------//

        //yearBlock
        $(document).on('click', "#" + userCustomId + " .monthBlock .mHeader .mDate", function () {
            $(this).parents(".monthBlock").addClass("mDisplayNone");
            $("#" + userCustomId + " .yearBlock").removeClass("mDisplayNone");


            if ($("#" + userCustomId + " .mhmPickerInput").val() != '') {
                var curr2InputWithClock = $("#" + userCustomId + " .mhmPickerInput").val().split(" ");
                var curr2Input = curr2InputWithClock[0].split("-");
                var curr2InputYear = curr2Input[0];
            }
            else {
                var new2NowDate = new Date();
                var curr2InputYear = new2NowDate.getFullYear();
            }
            var sendYear = curr2InputYear;
            sendYear -= sendYear % 10;
            $("#" + userCustomId + " .yearBlock .mHeader .mDate .mFirstYear").text(sendYear);
            $("#" + userCustomId + " .yearBlock .mHeader .mDate .mLastYear").text(sendYear + 11);
            fillYears(sendYear, curr2InputYear);
        });
        $(document).on('click', "#" + userCustomId + " .yearBlock .mHeader .mRight span", function () {
            var firstYear = Number($("#" + userCustomId + " .yearBlock .mHeader .mDate .mFirstYear").text());
            var lastYear = Number($("#" + userCustomId + " .yearBlock .mHeader .mDate .mLastYear").text());
            firstYear += 10;
            lastYear += 10;
            $("#" + userCustomId + " .yearBlock .mHeader .mDate .mFirstYear").text(firstYear);
            $("#" + userCustomId + " .yearBlock .mHeader .mDate .mLastYear").text(lastYear);
            if ($("#" + userCustomId + " .mhmPickerInput").val() != '') {
                var curr2InputWithClock = $("#" + userCustomId + " .mhmPickerInput").val().split(" ");
                var curr2Input = curr2InputWithClock[0].split("-");
                var curr2InputYear = curr2Input[0];
            }
            else {
                var new2NowDate = new Date();
                var curr2InputYear = new2NowDate.getFullYear();
            }
            fillYears(firstYear, curr2InputYear);
        })
        $(document).on('click', "#" + userCustomId + " .yearBlock .mHeader .mLeft span", function () {
            var firstYear = Number($("#" + userCustomId + " .yearBlock .mHeader .mDate .mFirstYear").text());
            var lastYear = Number($("#" + userCustomId + " .yearBlock .mHeader .mDate .mLastYear").text());
            firstYear -= 10;
            lastYear -= 10;
            $("#" + userCustomId + " .yearBlock .mHeader .mDate .mFirstYear").text(firstYear);
            $("#" + userCustomId + " .yearBlock .mHeader .mDate .mLastYear").text(lastYear);
            if ($("#" + userCustomId + " .mhmPickerInput").val() != '') {
                var curr2InputWithClock = $("#" + userCustomId + " .mhmPickerInput").val().split(" ");
                var curr2Input = curr2InputWithClock[0].split("-");
                var curr2InputYear = curr2Input[0];
            }
            else {
                var new2NowDate = new Date();
                var curr2InputYear = new2NowDate.getFullYear();
            }
            fillYears(firstYear, curr2InputYear);
        })
        $(document).on('click', "#" + userCustomId + " .yearBlock .mBody tbody td", function () {
            $(this).parents(".yearBlock").addClass("mDisplayNone");
            $("#" + userCustomId + " .monthBlock").removeClass("mDisplayNone");
            var yearClicked = $(this).text()
            $("#" + userCustomId + " .monthBlock .mHeader .mDate .mDateYear").text(yearClicked);
            if ($("#" + userCustomId + " .mhmPickerInput").val() != '') {
                var currInputWithClock = $("#" + userCustomId + " .mhmPickerInput").val().split(" ");
                var currInput = currInputWithClock[0].split("-");
                var currInputMonth = Number(currInput[1]);
                var currInputYear = currInput[0];
            }
            else {
                var newNowDate = new Date();
                var currInputMonth = newNowDate.getMonth();
                var currInputYear = newNowDate.getFullYear();
                currInputMonth++;
            }
            if (currInputYear == yearClicked) {
                $("#" + userCustomId + " .monthBlock .mBody tbody td[data-monthNum='" + currInputMonth + "']").addClass("mSelected");
            }
            else {
                $("#" + userCustomId + " .monthBlock .mBody tbody td.mSelected").removeClass("mSelected");
            }
        })
        // ------------------------------------------//

        //clockBlock
        $(document).on('click', "#" + userCustomId + " .mClock", function () {
            $("#" + userCustomId + " .mainBlock").addClass("mDisplayNone");
            $("#" + userCustomId + " .monthBlock").addClass("mDisplayNone");
            $("#" + userCustomId + " .yearBlock").addClass("mDisplayNone");
            $("#" + userCustomId + " .clockBlock").removeClass("mDisplayNone");
        })
        $(document).on('click', "#" + userCustomId + " .clockBlock .clockUpIcons .minuteUp", function () { //minuteUpClick
            var currClockMinute = Number($("#" + userCustomId + " .clockBlock .mainMinute").text());
            currClockMinute++;
            if (currClockMinute > 59) {
                var currClockHour = Number($("#" + userCustomId + " .clockBlock .mainHour").text());
                currClockHour++;
                if (currClockHour > 23) {
                    currClockHour = 0;
                }
                if (currClockHour < 10) {
                    $("#" + userCustomId + " .clockBlock .mainHour").text("0" + currClockHour);
                }
                else {
                    $("#" + userCustomId + " .clockBlock .mainHour").text(currClockHour);
                }
                currClockMinute = 0;
            }
            if (currClockMinute < 10) {
                $("#" + userCustomId + " .clockBlock .mainMinute").text("0" + currClockMinute);
            }
            else {
                $("#" + userCustomId + " .clockBlock .mainMinute").text(currClockMinute);
            }
        });

        $(document).on('click', "#" + userCustomId + " .clockBlock .clockDownIcons .minuteDown", function () { //minuteDownClick
            var currClockMinute = Number($("#" + userCustomId + " .clockBlock .mainMinute").text());
            currClockMinute--;
            if (currClockMinute < 0) {
                var currClockHour = Number($("#" + userCustomId + " .clockBlock .mainHour").text());
                currClockHour--;
                if (currClockHour < 0) {
                    currClockHour = 23;
                }
                if (currClockHour < 10) {
                    $("#" + userCustomId + " .clockBlock .mainHour").text("0" + currClockHour);
                }
                else {
                    $("#" + userCustomId + " .clockBlock .mainHour").text(currClockHour);
                }
                currClockMinute = 59;
            }
            if (currClockMinute < 10) {
                $("#" + userCustomId + " .clockBlock .mainMinute").text("0" + currClockMinute);
            }
            else {
                $("#" + userCustomId + " .clockBlock .mainMinute").text(currClockMinute);
            }
        })

        $(document).on('click', "#" + userCustomId + " .clockBlock .clockUpIcons .hourUp", function () { //hourUpClick
            var currClockHour = Number($("#" + userCustomId + " .clockBlock .mainHour").text());
            currClockHour++;
            if (currClockHour > 23) {
                currClockHour = 0;
            }
            if (currClockHour < 10) {
                $("#" + userCustomId + " .clockBlock .mainHour").text("0" + currClockHour);
            }
            else {
                $("#" + userCustomId + " .clockBlock .mainHour").text(currClockHour);
            }
        });

        $(document).on('click', "#" + userCustomId + " .clockBlock .clockDownIcons .hourDown", function () { //hourDownClick
            var currClockHour = Number($("#" + userCustomId + " .clockBlock .mainHour").text());
            currClockHour--;
            if (currClockHour < 0) {
                currClockHour = 23;
            }
            if (currClockHour < 10) {
                $("#" + userCustomId + " .clockBlock .mainHour").text("0" + currClockHour);
            }
            else {
                $("#" + userCustomId + " .clockBlock .mainHour").text(currClockHour);
            }
        });

        $(document).on('click', "#" + userCustomId + " .clockBlock .mainClock .mainHour", function () {
            $(this).parents(".clockBlock").addClass("mDisplayNone");
            $("#" + userCustomId + " .clockHourBlock").removeClass("mDisplayNone");
        })
        $(document).on('click', "#" + userCustomId + " .clockHourBlock td", function () {
            var selectClockHour = $(this).text();
            $(this).parents(".clockHourBlock").addClass("mDisplayNone");
            $("#" + userCustomId + " .clockBlock").removeClass("mDisplayNone");
            $("#" + userCustomId + " .clockBlock .mainHour").text(selectClockHour);
        })

        $(document).on('click', "#" + userCustomId + " .clockBlock .mainClock .mainMinute", function () {
            $(this).parents(".clockBlock").addClass("mDisplayNone");
            $("#" + userCustomId + " .clockMinuteBlock").removeClass("mDisplayNone");
        })
        $(document).on('click', "#" + userCustomId + " .clockMinuteBlock td", function () {
            var selectClockMinute = $(this).text();
            $(this).parents(".clockMinuteBlock").addClass("mDisplayNone");
            $("#" + userCustomId + " .clockBlock").removeClass("mDisplayNone");
            $("#" + userCustomId + " .clockBlock .mainMinute").text(selectClockMinute);
        })
        $(document).on('click', "#" + userCustomId + " .mAccept", function () {
            if (typeNumber == 2) {
                var clockHourValue = $("#" + userCustomId + " .clockBlock .mainClock .mainHour").text();
                var clockMinuteValue = $("#" + userCustomId + " .clockBlock .mainClock .mainMinute").text();
                $("#" + userCustomId + " .mhmPickerInput").val(clockHourValue + ":" + clockMinuteValue);
                $("#" + userCustomId + " .mClicking").removeClass("mOpen");
                $("#" + userCustomId + " .dtpBlock").remove();
            }
            else {
                $("#" + userCustomId + " .clockBlock").addClass("mDisplayNone");
                $("#" + userCustomId + " .clockMinuteBlock").addClass("mDisplayNone");
                $("#" + userCustomId + " .clockHourBlock").addClass("mDisplayNone");
                $("#" + userCustomId + " .mainBlock").removeClass("mDisplayNone");
            }
        })
        // ------------------------------------------//

        function fillCalendar(pickerMonth, pickerYear) {
            var tableData = $("#" + userCustomId + " .mainBlock .mBody tbody td");
            $("#" + userCustomId + " .mainBlock .mBody tbody td.mDisable").removeClass("mDisable");
            $("#" + userCustomId + " .mainBlock .mBody tbody td.mSelected").removeClass("mSelected")
            count = 1;
            count2 = 1;
            var monthDay = 0;
            var monthNumber = 0;
            var prevMonth = 0;
            //-------------------//
            switch (pickerMonth) {
                case 'yanvar':
                    monthDay = 31;
                    monthNumber = 1;
                    prevMonth = 31;
                    break;
                case 'fevral':
                    if (pickerMonth == 'fevral') {
                        monthNumber = 2;
                        if (pickerYear % 4 == 0) {
                            monthDay = 29;
                        }
                        else {
                            monthDay = 28;
                        }
                    }
                    prevMonth = 31;
                    break;
                case 'mart':
                    monthDay = 31;
                    monthNumber = 3;
                    if (pickerYear % 4 == 0) {
                        prevMonth = 29;
                    }
                    else {
                        prevMonth = 28;
                    }
                    break;
                case 'aprel':
                    monthDay = 30;
                    monthNumber = 4;
                    prevMonth = 31;
                    break;
                case 'may':
                    monthDay = 31;
                    monthNumber = 5;
                    prevMonth = 30;
                    break;
                case 'iyun':
                    monthDay = 30;
                    monthNumber = 6;
                    prevMonth = 31;
                    break;
                case 'iyul':
                    monthDay = 31;
                    monthNumber = 7;
                    prevMonth = 30;
                    break;
                case 'avqust':
                    monthDay = 31;
                    monthNumber = 8;
                    prevMonth = 31;
                    break;
                case 'sentyabr':
                    monthDay = 30;
                    monthNumber = 9;
                    prevMonth = 31;
                    break;
                case 'oktyabr':
                    monthDay = 31;
                    monthNumber = 10;
                    prevMonth = 30;
                    break;
                case 'noyabr':
                    monthDay = 30;
                    monthNumber = 11;
                    prevMonth = 31;
                    break;
                case 'dekabr':
                    monthDay = 31;
                    monthNumber = 12;
                    prevMonth = 30;
                    break;
            }
            //--------------------------//
            var currentDate = new Date(pickerYear, monthNumber - 1, 1);
            var beginFrom = currentDate.getDay();
            if (beginFrom == 0) {
                beginFrom = 7;
            }
            prevMonthDays = prevMonth - beginFrom + 2;
            beginFrom--;
            for (var i = 0; i < tableData.length; i++) {
                if (i < beginFrom) {
                    $(tableData[i]).addClass("mDisable")
                    $(tableData[i]).text(prevMonthDays);
                    prevMonthDays++;
                }
                else if (i <= monthDay + beginFrom - 1) {
                    $(tableData[i]).text(count);
                    count++;
                }
                else {
                    $(tableData[i]).addClass("mDisable")
                    $(tableData[i]).text(count2);
                    count2++;
                }
                if ($(tableData[i]).text() == mSelectedDate) {
                    if ($("#" + userCustomId + " .mainBlock .mHeader .mDateMonth").text() == mSelectedMonth && !$(tableData[i]).hasClass("mDisable")) {
                        if ($("#" + userCustomId + " .mainBlock .mHeader .mDateYear").text() == mSelectedYear) {
                            $(tableData[i]).addClass("mSelected");
                        }
                    }
                    else {
                        for (var j = 0; j < mMonth.length; j++) {
                            if (mMonth[j] == mSelectedMonth) {
                                var currentSelectedNumber = j;
                                break;
                            }
                        }
                        var monthName = $("#" + userCustomId + " .mainBlock .mHeader .mDateMonth").text();
                        if (currentSelectedNumber == 11) {
                            var constNextMonth = mMonth[0];
                        }
                        else {
                            var constNextMonth = mMonth[currentSelectedNumber + 1];
                        }
                        if (currentSelectedNumber == 0) {
                            var constPrevMonth = mMonth[11];
                        }
                        else {
                            var constPrevMonth = mMonth[currentSelectedNumber - 1];

                        }
                        if (constNextMonth == 'İyul') {
                            constNextMonth = 'iyul';
                        }
                        else if (constNextMonth == 'İyun') {
                            constNextMonth = 'iyun';
                        }
                        if (constPrevMonth == 'İyul') {
                            constPrevMonth = 'iyul';
                        }
                        else if (constPrevMonth == 'İyun') {
                            constPrevMonth = 'iyun';
                        }
                        if (monthName.toLowerCase() == constNextMonth.toLowerCase() && mSelectedDate > 14) {
                            if (monthName == constNextMonth && $(tableData[i]).hasClass("mDisable")) {
                                if ($("#" + userCustomId + " .mainBlock .mHeader .mDateYear").text() == mSelectedYear || (($("#" + userCustomId + " .mainBlock .mHeader .mDateYear").text() == mSelectedYear + 1) && $("#" + userCustomId + " .mainBlock .mHeader .mDateMonth").text() == mMonth[11])) {
                                    $(tableData[i]).addClass("mSelected");
                                }
                            }
                        }
                        else if (monthName.toLowerCase() == constPrevMonth.toLowerCase() && mSelectedDate <= 7) {
                            if (monthName == constPrevMonth && $(tableData[i]).hasClass("mDisable")) {
                                if ($("#" + userCustomId + " .mainBlock .mHeader .mDateYear").text() == mSelectedYear || (($("#" + userCustomId + " .mainBlock .mHeader .mDateYear").text() == mSelectedYear - 1) && $("#" + userCustomId + " .mainBlock .mHeader .mDateMonth").text() == mMonth[0])) {
                                    $(tableData[i]).addClass("mSelected");
                                }
                            }
                        }
                    }
                }
            }
        }

        function fillYears(sendYear, currYear) {
            var yearTable = $("#" + userCustomId + " .yearBlock tbody td");
            $("#" + userCustomId + " .yearBlock tbody td.mSelected").removeClass("mSelected");
            for (var i = 0; i < yearTable.length; i++) {
                if (currYear == sendYear) {
                    $(yearTable[i]).addClass("mSelected");
                }
                $(yearTable[i]).text(sendYear);
                sendYear++;
            }
        }

        function inputControl(inputValue) {
            var fullInput = inputValue.split(" ");
            if (typeNumber == 1 || typeNumber == 3) {
                var dateInput = fullInput[0].split("-");
                if ((!($.isNumeric(dateInput[2]))) || (!($.isNumeric(dateInput[1]))) || (!($.isNumeric(dateInput[0]))) || (dateInput.length != 3) || (Number(dateInput[2]) < 1) || (Number(dateInput[2]) > 31) || (Number(dateInput[1]) < 1 || Number(dateInput[1]) > 12) || (Number(dateInput[0]) < 1)) {
                    return false;
                }
                var dayControl = Number(dateInput[2]);
                var monthControl = Number(dateInput[1]);
                var yearControl = Number(dateInput[0]);

                if ((monthControl == 4 || monthControl == 6 || monthControl == 9 || monthControl == 11) && dayControl > 30) {
                    return false;
                }
                if (monthControl == 2) {
                    if (dayControl > 29) {
                        return false;
                    }
                    else {
                        if (dayControl == 29 && (yearControl % 4 != 0)) {
                            return false;
                        }
                    }
                }
            }
            if (typeNumber == 2 || typeNumber == 3) {
                if (typeNumber == 2) {
                    var clockInput = fullInput[0].split(":");
                }
                else {
                    if (fullInput.length == 1) {
                        return false;
                    }
                    var clockInput = fullInput[1].split(":");
                }
                if (!($.isNumeric(clockInput[0])) || !($.isNumeric(clockInput[1])) || clockInput.length != 2 || clockInput[0] == '' || clockInput[1] == '' || (Number(clockInput[0]) < 0 || Number(clockInput[0]) > 23) || (Number(clockInput[1]) < 0 || Number(clockInput[1]) > 59)) {
                    return false;
                }
            }
            return true;
        }

    }
});
