using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.Text;

/// <summary>
///PagerHelp 的摘要说明
/// </summary>
public class PageHelper
{

    public static void InitPageString( out string _strButtomPage ,int iPageCount , int iPageCurrent , string strPageName , params string[ ] pageParams)
    {
        string paramContent = string.Empty;
        if( pageParams != null )
        {
            foreach( string param in pageParams )
            {
                paramContent += "&" + param;
            }
        }

        int PageNumber = 5;
        StringBuilder sb = new StringBuilder( "" );
        StringBuilder sbtop = new StringBuilder( "" );


        sb.Append( String.Format( "<li><a disabled='disabled'>共{0}页</a></li>" , iPageCount ) );
        sb.Append(
            String.Format(
                "<li><a disabled='disabled'>{0}/{1}</a></li>" ,
                iPageCurrent ,
                iPageCount ) );
        sb.Append( String.Format( "<li class='pn'><a href=\"{0}.aspx?page=1{1}\">&lt;&lt;</a></li>" , strPageName , paramContent ) );

        if( iPageCurrent == 1 )
        {
            sb.AppendLine( "<li class='pn'><a disabled='disabled'>上一页</a></li>" );
        }
        else
        {
            sb.AppendLine(
                string.Format(
                    "<li  class='pn'><a href=\"" + strPageName +
                    ".aspx?page={0}{1}\" id=\"prev\">上一页</a></li>", (iPageCurrent - 1).ToString(), paramContent));
        }

        int iBaseNumber = ( iPageCurrent - 1 ) / PageNumber;
        int iCountBaseNumber = ( iPageCount - 1 ) / PageNumber;
        int iCountRemainNumber = ( ( iPageCount - 1 ) % PageNumber ) + 1;
        int iRemainLastNumber = iCountRemainNumber;
        int iBaseFirstNumber = 0;
        int iRemainFirstNumber = 0;

        if( iCountBaseNumber > 0 )
        {
            if( iBaseNumber == iCountBaseNumber )
            {
                iBaseFirstNumber = iCountBaseNumber - 1;
            }
            else
            {
                iBaseFirstNumber = iBaseNumber;
            }
            iRemainFirstNumber = PageNumber;
        }
       
        for( int first = 1 ; first <= iRemainFirstNumber ; first++ )
        {
            sb.AppendLine( GetPageStringFromNumber( ( iBaseFirstNumber * PageNumber ) + first , iPageCurrent , strPageName , paramContent ) );
        }
        if( iRemainFirstNumber != 0 )
        {
            sb.AppendLine( "<li class='pn'>...</li>" );
        }
        for( int last = 1 ; last <= iRemainLastNumber ; last++ )
        {
            sb.AppendLine( GetPageStringFromNumber( ( iCountBaseNumber * PageNumber ) + last , iPageCurrent , strPageName , paramContent ) );
        }
        //if (iPageCurrent == iPageCount)
        //{
        //    sb.AppendLine(string.Format("<a class=\"shu1\">{0}</a>", ">>"));
        //}
        //else
        //{
        //    sb.AppendLine(string.Format("<a href=\"{0}.aspx?page={1}\" class=\"shu1\">{2}</a>", strPageName, iPageCount.ToString(), ">>"));
        //}

        if( iPageCurrent == iPageCount )
        {
            sb.AppendLine( "<li class='pn'><a disabled='disabled'>下一页<a></li>" );
        }
        else
        {
            sb.AppendLine( string.Format( "<li class='pn'><a href=\"" + strPageName + ".aspx?page={0}{1}\" id=\"next\">下一页</a></li>" , ( iPageCurrent + 1 ).ToString( ) , paramContent ) );
        }
        sb.Append( String.Format( "<li class='pn'><a href=\"{2}.aspx?page={0}{1}\">&gt;&gt;</a></li>" , iPageCount , paramContent , strPageName ) );

        //return sb.ToString( );

        _strButtomPage = "<ul>" + sb.ToString() + "</ul>";
    }
    private static string GetPageStringFromNumber( int number1 , int number2 , string strPageName , string paramContent )
    {
        string strPageString = string.Empty;
        if( number1 > 0 )
        {
            strPageString = ( number1 == number2 ) ? string.Format( "<li class='pn'>{0}</li>" , number1.ToString( ) ) : string.Format( "<li class='pn'><a href=\"{0}.aspx?page={1}{2}\">{1}</a></li>" , strPageName , number1.ToString( ) , paramContent );
        }
        return strPageString;
    }
}
