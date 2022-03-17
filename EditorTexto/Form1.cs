/* TEdit - Editor texto e criptografia de texto

Licenca MIT - https://pt.wikipedia.org/wiki/Licen%C3%A7a_MIT

Copyright ©2022 Breno Prado and Edmar Prado

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Security.Cryptography;

namespace EditorTexto
{
    public partial class Form1 : Form
    {
        public string caminhoArquivo, retorno = "Cancel";

        private byte[] textoCifrado;

        private string sal = "MKzeSY2jReHxGTyM4/LwdBdS12r9BMmC/hyclvgVIP7+NZ2s1WEtmRWnkB/rlbHR0mMjVuaMSEYJU0lKH1i6R8fHIVm2nUjeczdzbP5mCOIJwLnB+4z9/X0jU9XaIghSRvU7HWzsm25t682wsnKs4d3lU8n1/yZ0yFL/2m0LyZN0AmbFlGgTSXKviaJef5uI7Mo6eeQHuwWw0g6EIJayidtHh1JbHA/Gfe602jh9P7Cug2M8oI08A4jZbnjtkmLvV9Iqqko+kuiAcX+es4E+WdpsaddXmVzYl+hxc+qAmTm7G3bAM6RPxHkA0hjuqwuIEs1AdHkj0xbY1BKxcYmQ9y3GfaMtZlZ8eDKbduLWhLHWxc5NXnN+s9zjUGMiZZ6YjdZk/17BgF1+s4XmiZMcdEoiCFBSx+dwl7LJqVWGZcjq6RlPXJzqTvwKonXOUeQ+krEXuAwCxOy8LdNq1IG82tNHexEfb2xCjwMbSH5ORW+VWuY5vW30GUpXnkhDpUF4dHzdsYE1X7N5GaOc3Amndf2lmci/s7soZIXnB3q/AY91TV3VQScsrf1ZDfUycI+1Q8iiVdMuirO7RH79Zi6a1qOE90pvQCqlhPsmnrYdAmdX7YuATGjjkrQ8DnToHxJ3YQwcfpqGRAu9KNQ5BHmAOzKru677Ug9/fhxWzNgc9UaoOdJMp7a0kO8NmLStAGTPJpdh+vLEmq/OI7T5KXUawAjSKWeGG4XrBVfomRTOmkoKpZJCTWODkDZ3RgJw47XU019vVA3gaFJAoL/JoL2GaY7jqDxxqq9OU5s2BG6qfEGCcpr7XeQr7vV7Dk+EeYJ3/uSNiIV+Iylz96xb2dbzXX0kMIUNrag/HAwEqpl5K0cs7NClcB5MBRdG6D2Fi8/Ch/PU69LulF7BsEOFjkOPaCkMmzMlBGHhN1az5eB/tYzeovNUfd5ezZSH6fEBSdXgaqJH4kJ9U79W7LF5A4o9cw9T8gocCEzr0dNI1RKagQNWeg9+eGGmq7RmEgNjJKfHFjzwEc6K4b51gblufL2vRMTD5yD6MOAOucGwc8m7Xi2RUxG43c8/f7nm7XwgIMdXXV3czdajeHDbs6GvEYsSGA19597jaqvoRHhB8z6p/lAcAi/gMwJgXlZoTb0MrVMD4vC7pyR3diQufJqEDweGHIiAXMFZt/GB8M2Vx71fmxAzBa6xsjyXDK2fqXLKMo8HIKsb5uWftbB07VP9AdywtiY97ABLRSPDdCbxI+yIlU4ltnYtxrcK9vgjDPcofc1FEShXC6dqK2RTW/kd4X2GSL3C3w3kQ+ozXdKm0g9qo88kwUonU6+GOu0Z/pyAW9UR/NLQ124nfmhYeHiT6gQRl0vC+8lr+HqQhN9dz6X52v/cdS5Tytns3moZmVWH4rxy4wKuxoY2K+1fa1jW/N3kWQ0OwuN0tOEUitVSP+Twrs2sgmzHGuGS6n/DAKMTyqM/Abya7G25NlDFTu43lxLQPbMaT7rWVgfX9mu4IEd9czgCG/h5x2sjMxgnl8ulTUAy5NTQoTxTQn/QjY3bc0seocI244cHsLtCPSg2q8F+32aLMLl7bneCPLgToVcyhTF/m9vpTBbcPikLIXQR0zFU/ZJYea6J2n+cO7/STge5ehx6TKUGy0DayRw9/4A97wlPAPTiaJsTInQ3DgNHtuXWmK4NQVeeKOUm5bzQDXuBodAudANgv3YrXyZIwH3bHR/h8RB+5Lyx4SRG9ltu1YZX9klygzh4scYcNcmGYAcLYpJPcGEDBY/q/fE6lrNaQCkBfkLxPMDPgrJjYFThw0VRdL6Qd9IcFyoKqwKdNaNROJBZ32KyUj0P1x/oTqzPXMYHe/LtfYgxwn3TVe9uBe1p+dFkDVT8PlyfBpNihYhtjkgoQ1leOtGUC6RHFmB/WSy14lhHu0w4BjyVj92mOer4RVLp9eqpvmw1ws0dJJqmabHlGZv9z8kD3ttF1Nkd+RnzO2tRkCWx6nx6JYjXsha44lam31ApdZGPJM+UtaxeXvTmJYk0KEGRMNy0AVclffMOd7RCCC74qgJstXAjdKfZjrwhLi6/uxy2RmGqAQkJYBLeWMdDTR0f8mXJ0+ss0YAcxTYGrNX3xJMa6ttOYVSextnzjsAvI5pKQPLjhz4jbL+XBfhzXw5CklmhjrGuhrd3BhP3RKnfAbDWWECMPX7VNI5Ksr/satPtAs6NvM0jBb3BmrGFPbLzj0DK5yVqGvO5F+FYwV6qXG73VcRKAmTHNRa04rszu+9ZC+yTmeGhs9g4GxXZI36ttZXQlhWDkoJ+nipUX/6vhSKQT17SnREj52isALOS9cxBCdmAET0nEgRVIGD3sc/sjrvk6E63oxa/VdbHF4JNRQWuMkWN2iGQhb0z2BKlhg5oBpskvZ0SBbUNozpRYIatZyize1AjH+F9YqVEkcCbcPhY/MVW9c1Wvc5vYstjfvGSdrLORuUi6p/VYogREtTU8ZBuISuNGZUAqoI45BF67x9GGifEdDyUX9Np+9qyOOHenKnMkR6/udCyWlGwsy/SGjJtAVz0PCWl8K0n3CkBEomyxdXMoktr9L/EXSfuH/OH1aKqtAWhCviUxosOE1G8hGffRTps4SmxAGLDWGBXmSQZMGv2C+nuOlUA3SvuIbxnkBvdifgI7yNveZea5yZ71KRp5RDTcqikV2hBReqHV58ey0cjz+0Qbfk5b3lg+/0TiWvY7McwTbVOC0orRfO0SjEKYo8t5b56YttlZNVxRA8cl7ycBxBUQRo3lRfwdjtZewV6iyq2QodIrTjCF9JS3nARZNXrgTpfUt7g7egzhw6YQDrBNhcSPOg0Fy8r1/n4Ghk0SaQRbswDqPF5t1fYcu2aco2OtrWnEvYXdjCt0tsgqMnli2n55Lmvs1kZlKKSqtbpF6JZKMjjmgPTKrCPTGkD1LYy8ohOA+IfJPc/h7iuMnU2H29sigZebRh4h1ZKQXemYytVTi4DmXrNrpyK7aCUmNLONnmyhqVHaxU1fWdW7GmNo+PINrynHMVMeTGndddlbXXk+7OoxAztgWjKTQm3vSEo4mjsDA/i5tQfk8PB0DrhUe1mOeXuiTFkGAvBv8Pi8OlSBWxeZHCNFGYVdiy/jLW3DG+YSNRsCBtnwVs9rzuRP8cAcdf23+1OExkW5R5gg3zItX/JISkzTR0/Rom+B+7vvPOA97UA7i297mkei6gEOl66bRHLLfP/+24P8IkjcvXNzsiSLp0SVdXKq2ZA+ll09vDj7pspnOeUor13pPCGS6w+yCts059u8BDK2FmRKdCC3ZvWeV4k+W48JAejdPFcEYN+lmpnEPjzyX8vsAKhYu0b74JKJhRJ3v/4oqn8lMJs56S2124q+WkWjaO5DqEeUfQABehDcNy93uJSezzcJCdykUR/N4RF7taG3ppy06XM7FMZxd+ngXyFUVIEMoLivHBLZiR9EaYsyq10lBEF4sScJrnuBCLSgh6DJ3Hzd8aPGUODQW6Rtcn+cvuagn6rzJLDTBUpnmU72Fb9l0xzQD+NauS4sCht4YaCRsEG/T/VuQc3ZZcH79oD8YMvkYZ0ohSp5KGHAW8D7NkJz8SqbrZi14w0rhxY5QMri7AL5JQ6BypF6cp59WNyqyPZEiu9UwPHSHREnvlFR3zz95IzWrYCWiNKr0NxJ6l1A5YRULJOao7PYrb4lJzc/EAor4IO+pY7xyihNh0fAUZajYS88NqnlEpvInaLmmnNz9nzhT28rf6w2xABR66N7y9HU1E4ECRyXBEorqPkWELhR7rEbr6EkUIzBy2xClFmpNMs89GF5LoSQgjjYmaKadsnIiV2PAC6Ggrqt1Jvy4IkLW1l3OJ+BsTDMPd92UztV8btHBLXIyJoLKSftHFlbIJ/fqeQrEUVIJGZj6WV8+JkNkJhytMndKEpcYj4nQuzOManfxFakWVOfF9Gv0jLSg4VXxu/WLLJLkjFyJVytAyIDquf95s8/ihVHdgMilpOxF8jh7U0GGtMroZLFuhppwWsUeVXJF4h35W054U2lxN7YhHNs5kJ6eZVzc0ssCMeOlwy2Obga+wmceGf+8NwZi7SKeeTd/cUl3ylqNq/LOjBw3VrOAhY/k3+qFZQ+/NCeXzVbqRNwUpi3hvJDQrcw1i2d0RTkCCysd5K/h8RwcdGWbvoGnL+gE9wBAP1AgXJNTTENfRCIk+ojkMNq84MYsJTUk+bUcO/r0dpAw4s4+nFW6G8/rMhiP+lLOvgIlOzFlR4d/WEnXRVH1bNPH+4XYlFFBUS1zQIha7aArmdnVF63ITFd5K/3P0Md37hvkP/NgJgAqc77zh99h7UTZJNrKoCkfPW0ZgcPKI+lFGWy4adeQ38uZgzHbQdbkNYIdV2PziA70XUqBfU7Vuqx33VazuK75iw04/YGnQ0w6Ma+bV8lK0klHuNcXECCniw1TXuyud0CsiR93V26Et4ZnhyukSswhLAWEFA3gfdOUajzYveO2VctJdhE4t6a7X+6QcA+uEcklVUYgvArIypBgpwmDx4WTVC3IgKhDBIz0be+Iy4YV460gUbmStviDuuwaYPZ/yPvd2eQgplEu9ONqnCXlP7bHUv01FDippdsUjicAD52wb3rVsPDfK65boyD2da5FRefZ/O18A1pCct8Q+5FbHe+Qm+CGYvtIY13WklnTG1C4hY/Ao4ogn2ryB8nNu3IqjsV7TdE2E+f72FYB9kzDxBMpV6hF8PGVb1KrnNyfmE76czIta+yhW6oKKuY2PTJ4nnGrKC1ohmMohY0BpeHDc9q15dqqvRTRcmmW+2pczVcV2UVd0ENfVn0oLKpDabFEmFcQrayiheraxk8Kn14nTngOEDgFxaiN2aNw0mgYvIKMTbRziikN8/M6TvIuwI38Mpy/IMAHtBViICATSSpYeC84+Hp4vx5ZThlQCIfE+Fe0I0G+6aGZZN1xYwwq6axih4c2EC/BDTilfAA/2RQbR5xPY4uJsYmRRUSxY5le6VyaVbqZ/E1f/BmKindxcklZmqZKGsmpXQuw0FrC+FqTN5eAjhKTmdhoWDxs76WZr+RsrrOR/ZB+Htbu6mYkGEGtGZkosPPJ1fD1XR3olxMxDODFxwCgVV+SOXM7Qtg8xVbveTHK5jEMueacI3fWkeU+3QAkRtl9sWwkMcu5KmxpbWhkpzPM3dTLNAi7AiJrfBSkJcDGOHoelSkvHevl3SeVKQuRNcN/RG+zxsK6Mip/BeoD3engiY06JceXrScG1VvFDb4is1SysHrrJoNflvoQ5GlQCUBefnshPrriycD8LAOhAmGIEtSJ4MZU6aPijlBTMtw8Abrf5aLY2Q47IRbgX51j4I1gHI7+xFfzReaH8iW6fH4+iMveBTsS6mQHIgvVACbMMh5jcO+IivayAoZvfVwYlFTSP/I6QQLFpCjzCw/FGh0In4mNeGGCYTWsNPK1iU8ljZblQI0HpVyAvumEZpkJu51Uo36jQObmbeQ+sHs/khmcgRkTkVU/uNOfEk2I7bNJpUxCLbY5u13tNzGeyxuUNjuQsr4TaDthLQwM9saXqMk3GhEj1TRYbwYuEZfwP4XR01pplIXGooafmvFHqvhxrAWkok1t0UQrSFm9KmoJRo1VyPt/4cTBnR5iLHG8qEL6ZhxMD/BtvdB/S8PhXPlhKmcOwijKmtqSwku4EUUUgmNymEBqBFzXEBhsIGDnUu4TuHS5BMjsTqQ1kTN5f1jo+LJwtcIFW35o6vWhhev4SGwllPE9EJ7pPgGAZ78edRFZq8YTCkqMFVLH23A9l+1ZNMRpBR+BZDESFa/gWS85ZLALMcvra84zHopBeMvfR+7VjpsufWX9bgrEm8a4wRZS4471FhZ67CgsoIcoj7HCLIaoD8kHVNh/a40bBjS+i7tyIdnpil/01Kwg77+8VdzbIuqQ5jfA2nVsUuPaBE04XegRMcobZcYpZnI0IK/Gs0HfYcFwko8pLKxm6EA0tQjGjvZAZIJlNBtPezi4OSMPNKn0Ix7efHYsBjcpbrBhUP1Qa8QvG6nIkN2HMOtqHAgRedig2mw+Z5lSbAE1DPCCB184HbzmaDj4fk/gp8KjrvRxNiC83PMMTq0Fb5Sg4k1hET03S2NrzbSLc4PNC36vwxYUuJZtdIHzf+OROyFQ/5RRb/pbYXldRkfXhBnO+PkOtf/4o8104KOdTH/4pSd94As1pkNcWVq+T0dgEO1Js9d/m/uKHUskyVZhQs2JNmv8ROcWFjZ2nPVsgIcGMSoaqYGbOr9EZ4/tbQRIrATDcA1csn9i3O+XRBk//4WMrs3Oqa1sYtI9750LfGQeSnq8WUI68iHJdZ4QWAI7URBom/X7lLaCZ2y0UtQGHM0P/nSmujCo/YiV60I/MCWU0mlqClV2WuXphzQc9tltlQ1zx4C7lsjAfOp38wsmA78g56hxYVaFiRJBl81MA0HawJTv5rRgz0W6j+1+6moiz/Ao4uLFSiIQOGkggizjYlpO1yFPFRItlQ8Bh72+adwQzZ92G87B6tftYE8NYVC/zfuEuFu8zyL8Ym6ktWEj0f6sJ57dR42ns6T4pEts2hOS5MjqNzS6YSnIe17R5dGLUn1eGhleBiZ8DkDVOnKDYwNRHhh3RbBeKX+ugz9yMJHbAVrOBwVkuuicNPGjHzSV4lFuUIUoxmid9g40H6h6Gt4P0d+vbBGaUlg723+LoWYy5G/0R5Ilri2cMuyv2iAgB4DstbfM9U1/JpJToZKt7cc+m0nwr0rcmY3yRYTqIsTUcZxx3t07bIBFCVE0+ZV3tQC6p/5ejfvcCUkG3J8LkHmBmniYi5win5PGPYzAlRrwnPkJKYUsjRuQzZ3ivkxD1YbjHPuVj8OCuOL5jTQlveSJ3sEyLiCF3JPaxa6o4BlbxaZl5sMlNgCAirZIXjyxcjeF6Ze0oZxjdOuUnz53FmlSvxZVZRyJt56Egz8DcoVqKpLFiNcbBxoowxyzLALL2uwdjoQFafM5vhVvo3Dll8nkuh2nu0FwDMIwcN6RHm250YoC3WTP7hlwRDciiZJMUndCEO/fNHDsw17wpWdJUySAI3gEBQWrUEVILIJMIEFJn3oDwdVoZjHFF+z4GiLMadlNURML77p/H/Viop06yCUmNi/YqXOc4h504qe6Qm5YxQ4XXdUxlf/wUHBz7D6BXsd9BML636FyQRZY8YP21fnxi5z/0+z8eCQ7AEuve/cKHWf2n2dNQRn4QDPejsvOZrasBChkuPJgXHQiUmZhpr4+HCjaNhslpWSgwz2pMDg0HOhtfefObOdxp89RIk9VRTqUb651I8WvH4Ahmk4scbFaFTNHG1jac6iIV/6Kbh1VptGrw5iM4eNmWlG5Oz+LmirhW3q5bwQEjsdPfiFIwvb+sfIwV0y9P2UGyrEnTEKxpz+nQlNcNNNvMZW2dsg9AE3TwtLM0Mpll1cJcT0tUYEomJ70SHdN/ikqh+2SfT7XFrstvG3k4XUGo9XamvEnZXJcagHWpdoiYmd2HbwTbSCE+p10irNy0dW1NkwUTR/iVlfR19e51GQKvAyd39lbkCrPKTCsnfLbmYqzXyXayE06vTERCPwbnBBfIzraNWoDi96LIprHG6cEfgPNRh037g8nIeed8Uo/9ka6BmsR4H2SBUm1o8eAl8LNxzx8GhZ4oOP4MRSlnhyft2Ki008ykTDqLn35VI2Hfl5R+hkYxC8VC0l8xIZE+U6TGLCyZytKCggbe411bFKjmoMSXPQxCq/OrXs1MPucYfJGXivUGHiYOjy02lILNISRjtU/LZA03bgFPjlgeCp03h6DJEM1F/SFja/Zt1+N55/Ex9frSkgSGchMpW2d3GfV+cgEt73vAjAiRbYk3c1QZEM5JARAvcm5pz+h8kJyaU+WxPibtR7epYZ0zhJTgv8E6hf8lIeqWgLTPRmAxh04ahH2kgXh8imkDby9b7lrtP4UE6qHbrzyU8hKEdKuPbDnpLpkPBkYCE+2i5Egu5OLSdnE7t7V5WqJZM1ap3aaMfVbBPPUA2Jxno87CmZiaqxuzEUaxpAnRuo271x6q/yFpeAWTFTL1wVc/1iB2N4UlaHYbfiTTWwwlNjftmQBlrN6E0secav+OYfemuAUNzbAo6Csa3voBGMlz5vO5oQJtTcfB8fbfETjuuSc+BNLPf9Hm5sNuhlERklNhrQImOxUKEKGJxjuxymzHqOCkLEVJYL7by+pZcBaujGdi16DGNKfJpCbwskeN+JhgpMgoXZbRyfMYMdl1flB+eVe3DP4i5ecGZ08gTaCDwpnVzuCQ9+Gj4cPFmNGFE668pufcRENQxMxajVWHiGbCe2kFG2UzkNdYFrpr7q4dtFKgXg7UyTyx/EYWkJVwX0s9GjPJEHNdgZe6GPossdHL1cu/hci9XpZicpYzKVfl4MnqFpxrp6lXw+QbN0AJlDbf43XnGg5Um6EufQTnzUCcUzWo09fWGMs8bqfL25+w0K/b3udk25Pq58ma2VLOG8froOTcalVTouxs75KpUfCwRsTcUVsKoxrjWp8SoXrM28gsvvINQXUT9Uk79Ja1YAPnukJrh7MP98hpMIQn3IkJ6iHi72oBhLNjcvulCVOS8K2w7MLkvvHxtryR3gynB2ux4g3uwpOvMK0qceiFa1umbGTmscVV0Y/SJa8rGcldRUxvwsGByZKDlJ3MIMXnVUT2MGql0kioW8NQEZWmrlBpqBw9wjyZzmHPPXvWOUC5jOPJJFpBza4yAR8UFO1MnD4jkLpkBk6nDcY2Zk0YGbO2DU3YPc9808aMDzdDRYl5bbnm1btZKH1KI8LjSzmEIBZOiKZ1dOWTRGpz1smodxf28yFMgFs99AUfl5GgTR/Jg7GH+9Pob2W0lsoI0munKHEsQ84goq9vSTTbkId2BMVzfGzbtBTtnYJPPKf30nUU7jCIgXCxcO0sfvNEPt7yvyVVUFpqJ4tmU51LrT31K8AXYOoF1oWTfKjwCjKeZW1x18mrPB80eoOnbQn5hyxcUXFcxFbjxOUBz5qgftpQdlHjoJNnoeA==";

        private string senha = "12345";


        public Form1()
        {
            InitializeComponent();
        }

        #region FormSobre
        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sobre s1 = new Sobre();
            s1.Show();
        }
        #endregion FormSobre

        #region MenuArquivo
        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var slr1 = new Salvar();

            if (caminhoArquivo == null)
            {
                sfdSalvarComo.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                var opcao = sfdSalvarComo.ShowDialog();

                if (opcao == DialogResult.OK)
                {
                    caminhoArquivo = sfdSalvarComo.FileName;

                    slr1.salvar(caminhoArquivo, txtTela.Text, false);

                    // Define OK para ser usado no botao SAIR e em seguida Cancelar
                    retorno = "Ok";
                }
            }
            else
            {
                slr1.salvar(caminhoArquivo, txtTela.Text, false);
            }

            _ = (caminhoArquivo != null) ? this.Text = "TEdit - " + caminhoArquivo : "TEdit";
        }

        private void salvarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            caminhoArquivo = null;
            salvarToolStripMenuItem_Click(sender, e);
        }

        public void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdAbrirArquivo.ShowDialog() == DialogResult.OK)
            {
                caminhoArquivo = ofdAbrirArquivo.FileName;

                if (File.Exists(caminhoArquivo))
                {
                    txtTela.Text = string.Empty;

                    using (var objectFile = new StreamReader(caminhoArquivo))
                    {
                        string linha;

                        this.Text = "TEdit - " + caminhoArquivo;

                        while ((linha = objectFile.ReadLine()) != null)
                        {
                            if (linha == null)
                                break;

                            txtTela.Text += linha + "\n";
                        }
                    }
                }
            }
        }

        private void defineCaracteristicasPadrao_ButtonNovo()
        {
            // Voltando as caracteristicas normais dos componentes abaixo
            this.Text = "TEdit - Sem Titulo";
            caminhoArquivo = null;
            txtTela.Text = string.Empty;

            // Ex: Font("Arial", 12, FontStyle.Bold)
            txtTela.Font = new Font(Font.FontFamily, Font.Size, FontStyle.Regular);
            txtTela.ForeColor = DefaultForeColor;
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtTela.Text != string.Empty || caminhoArquivo != null)
            {
                DialogResult opcao = MessageBox.Show("Deseja salvar as mudanças?", "Novo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (opcao)
                {
                    case DialogResult.No:
                        defineCaracteristicasPadrao_ButtonNovo();
                        break;

                    case DialogResult.Yes:
                        salvarToolStripMenuItem_Click(sender, e);
                        defineCaracteristicasPadrao_ButtonNovo();
                        break;

                    case DialogResult.Cancel:
                        FormClosingEventArgs cancelar = new FormClosingEventArgs(CloseReason.UserClosing, true);
                        cancelar.Cancel = true;
                        break;
                }
            }
            else
            {
                defineCaracteristicasPadrao_ButtonNovo();
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Esse metodo não está sendo EXECUTADO IMEDIATAMENTE - CORRIGIR
            if (caminhoArquivo == null && txtTela.Text == string.Empty)
            {
                Application.ExitThread();
            }

            DialogResult opcao = MessageBox.Show("Você deseja gravar o arquivo antes de sair?",
                "Sair", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            switch (opcao)
            {
                case DialogResult.Yes:
                    salvarToolStripMenuItem_Click(sender, e);

                    if (retorno == "Ok")
                        Application.ExitThread();

                    break;

                case DialogResult.No:
                    Application.ExitThread();
                    break;
            }
        }

        #region Imprimir
        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument imprimirDados = new PrintDocument();

            PrintDialog confImpressora = new PrintDialog()
            {
                // Configuracoes padrao para impressao
                AllowSelection = true, //false
                AllowSomePages = true, //false
                AllowCurrentPage = true, //false
                AllowPrintToFile = true, //true
                PrintToFile = true, //false
                ShowNetwork = false, //true
                ShowHelp = true, //false
                UseEXDialog = false, //true
                Document = imprimirDados
            };

            imprimirDados.DocumentName = (caminhoArquivo == null) ? "TEdit" : "TEdit - " + caminhoArquivo;

            if (confImpressora.ShowDialog() == DialogResult.OK)
            {
                imprimirDados.Print();
            }
        }
        #endregion Imprimir

        #endregion MenuArquivo

        #region TeclasAtalhos
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Control | Keys.N:
                    novoToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.O:
                    abrirToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.Shift | Keys.S:
                    salvarComoToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.P:
                    imprimirToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.E:
                    sairToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.L:
                    fontToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.B:
                    coresToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.F1:
                    sobreToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.S:
                    salvarToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.W:
                    quebraDeLinhaToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.D:
                    horaDataToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.Z:
                    desfazerCtrlZToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.C:
                    copiarCtrlCToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.Y:
                    refazerCtrlUToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Control | Keys.V:
                    Clipboard.GetText();
                    break;

                case Keys.Control | Keys.F:
                    localizarCtrlFToolStripMenuItem_Click(sender, e);
                    break;
            }
        }
        #endregion TeclasAtalhos

        #region MenuFormatar
        private void direitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtTela.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void esquerdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtTela.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void centroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtTela.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fdFont.ShowDialog() == DialogResult.OK)
            {
                txtTela.Font = fdFont.Font;
            }
        }
        #endregion MenuFormatar

        #region Temas
        private void corTema(Color backcolor, Color forecolor)
        {
            if (backcolor == DefaultBackColor && forecolor == DefaultForeColor)
            {
                txtTela.BackColor = Color.White;
                txtTela.ForeColor = DefaultForeColor;
                menuStrip1.BackColor = DefaultBackColor;
                menuStrip1.ForeColor = DefaultForeColor;
            }
            else
            {
                txtTela.BackColor = backcolor;
                txtTela.ForeColor = forecolor;
                menuStrip1.BackColor = backcolor;
                menuStrip1.ForeColor = forecolor;
            }
        }

        private void coresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cdColor.ShowDialog() == DialogResult.OK)
                txtTela.ForeColor = cdColor.Color;
        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            corTema(Color.Black, Color.DarkGray);
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            corTema(Color.DarkGreen, Color.Black);
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            corTema(DefaultBackColor, DefaultForeColor);
        }

        #endregion Temas

        #region Eventos
        private void Form1_Load(object sender, EventArgs e)
        {
            txtProcurar.Enabled = false;
        }

        private void txtProcurar_Leave(object sender, EventArgs e)
        {
            string textoPesquisado = txtProcurar.Text;
            txtProcurar.Text = "Digite sua pesquisa";
            txtProcurar.Visible = false;
            localizarTexto(txtTela.BackColor, textoPesquisado);
        }

        private void txtTela_TextChanged(object sender, EventArgs e)
        {
            // Como seria fazer essas combinacoes usando ENUM com [Flags]
            if (caminhoArquivo == null && txtTela.Text.Equals(string.Empty))
                this.Text = "TEdit";
            else if (caminhoArquivo == null && txtTela.Text != string.Empty)
                this.Text = "*TEdit";
            else if (caminhoArquivo != null && txtTela.Text != string.Empty)
                this.Text = "*TEdit - " + caminhoArquivo;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs evento)
        {
            sairToolStripMenuItem_Click(sender, evento);

            // Habilita o cancelar ao clicar no botao X da janela e clicar em CANCELAR do MessageBox
            if (evento.Cancel != true)
            {
                evento.Cancel = true;
            }
        }

        #endregion Eventos

        #region MenuEditar
        private void horaDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;

            // Arrumar esse codigo para escrever a data no local do cursor do teclado
            // E nao no final da tela
            txtTela.Text += dateTime.ToString();
        }

        private void quebraDeLinhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = (txtTela.WordWrap == true) ? txtTela.WordWrap = false : txtTela.WordWrap = true;
        }

        private void desfazerCtrlZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtTela.Undo();
        }

        private void refazerCtrlUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtTela.Redo();
        }

        private void copiarCtrlCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtTela.Copy();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtTela.Paste();
        }

        private void localizarTexto(Color corMarcacaoTexto, string texto)
        {
            string textoProcurado = texto;

            if (!string.IsNullOrWhiteSpace(textoProcurado))
            {
                int i = 0;

                while (i < txtTela.Text.LastIndexOf(textoProcurado))
                {
                    txtTela.Find(textoProcurado, i, txtTela.Text.Length, RichTextBoxFinds.None);
                    txtTela.SelectionBackColor = corMarcacaoTexto;
                    i = txtTela.Text.IndexOf(textoProcurado, i) + 1;
                }
            }
        }

        private void txtProcurar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                localizarTexto(Color.Red, txtProcurar.Text);
            }
        }

        private void localizarCtrlFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!txtTela.Text.Equals(""))
            {
                txtProcurar.Enabled = true;
                txtProcurar.Visible = true;
                txtProcurar.Focus();
            }
        }

        #endregion MenuEditar

        #region MenuFerramentas
        private void exportarCriptografadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cripto = new Criptografia();
            string textoCripto = cripto.criptografar(txtTela.Text);
            cripto.salvarArquivoCripto(textoCripto);
        }


        #endregion MenuFerramentas

    }
}

