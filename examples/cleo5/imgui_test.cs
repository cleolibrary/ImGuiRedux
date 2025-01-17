 (  ,  0 4  8  <8"cleo\example.jpg@   "IMGUI_CLEO_DEMOG"(�  8 (M ����"  �C  D"ImGuiCleo Demo Window(    (F"DE"
HD"P+"�  8 ,M ����)"�

T	ImGui: %s
H "
T�

TFramerate: %dP "
T*"�

TCLEO: %fD "
T)"+""WindowChild"TabBar!Checkbox,Button,Input,Text,Styles\�  8 \ M I���+")""Show version info,,*""Show timer example44)"+"�  8 \M -���+"�  	"Arrow buttonsM ����"Left '""Right'""Up'""Down,"+"�  	"Radio buttonsM ����""RB100'"""RB200'"""RB300+"�  	"Regular buttonsM -���M"S0 `d�  "Normal button`dM )����
Normal button was pressed�'"�  "Image Button@`dM �����
Image Button was pressed�+" `  d M"S1 `d�  "CB 1  �?          �?`dM v����
Color button 1 was pressed�'"�  "CB 2      �?      �?`dM &����
Color button 2 was pressed�'"�  "CB 3          �?  �?`dM �����
Color button 3 was pressed�M"S2 `d"Tip:\n\tClick the below area�  "Invis button`dM b����
Invisible button was pressed��  2"HOverM 1���"Hovering invisible button+","+"�  8 \M 1���+""	Int input� �  "Float input�̋B      �B +""
Int slider 
 "Float slider  �@       A +"!"Text input widget
h+" `  d M"S012 `d�  "Rest Inputs`dM '���3"	Int input�3"
Int slider'"�  "Rest Sliders`dM ����4"Float input�̋B4"Float slider  �@&"      �A p  t  x  | #"Color Pickerptx|"COLORBTNptx|  �B  �A&"       A"Text input: "ComboOption1,Option2,Option3<<�  8 \M ����+""*A little brown fox jumps over the lazy dog"*A little brown fox jumps over the lazy dog"*A little brown fox jumps over the lazy dog  �?          �?"*A little brown fox jumps over the lazy dog+""�A little brown fox jumps over the lazy dog. A little brown fox jumps over the lazy dog. A little brown fox jumps over the lazy dog�  8 \M ����+""Red checkbox+"<"�   � <"	Z  � <"x  � "Show version info,,>"+""Button with custom style+":"   A `  d M"S012 `d�  "Rounded button`dM �����
Rounded button was pressed�="'"�  "Regular button`dM �����
Regular button was pressed�"""�
  8��  4  ��M 9����
Timer test message�� 8  �  �
tM �����
tM ���   *����  8 (M ���� (  ���� ( ����VAR    gShowWindow �   gVersionInfo �   gRadioBtn �   gTimerExample �   gPrevTimer �   gComboSelection �   gImage �   reduxVer �   imguiVer �   fps �   temp �   tab �   szX �   szY �   text �   r �   g �   b �   a �   delta �   FLAG   SRC �"  //
// ImGuiCleo Example Script
//
{$CLEO}
{$USE CLEO}
{$USE imgui}

const TOGGLE_KEY = 116 // F5
int $gShowWindow = 0
int $gVersionInfo = 0
int $gRadioBtn = 1
int $gTimerExample = 0
int $gPrevTimer = 0
int $gComboSelection = 1
int $gImage = ImGui.LoadImage("cleo\example.jpg")

while true
    /*
        This must always be 0 to render ImGui each frame
        If you need to wait for something use timers instead,
        example below
    */
    wait 0


    /*
        All ImGui code must be wrapped inside the BeginFrame() .. EndFrame()
        You need to pass a "UNIQUE ID" for the frame name.
        Use something that's unlikely to be used by any other scripts
    */
    ImGui.BeginFrame("IMGUI_CLEO_DEMO")
    ImGui.SetCursorVisible($gShowWindow)

    if $gShowWindow == 1
    then
        ImGui.SetNextWindowSize(350.0, 600.0, ImGuiCond.Once)
        $gShowWindow = ImGui.Begin("ImGuiCleo Demo Window", $gShowWindow, 0, 0, 0, 0)

        float $reduxVer = ImGui.GetPluginVersion()
        s$imguiVer = ImGui.GetVersion()
        int $fps = Game.GetFramerate()

        ImGui.Spacing()

        if $gVersionInfo == 1
        then
            ImGui.Columns(2)
            Text.StringFormat(s$temp, "ImGui: %s", s$imguiVer)
            ImGui.Text(s$temp)
            Text.StringFormat(s$temp, "Framerate: %d", $fps)
            ImGui.Text(s$temp)
            ImGui.NextColumn()
            Text.StringFormat(s$temp, "CLEO: %f", $reduxVer)
            ImGui.Text(s$temp)
            ImGui.Columns(1)
            ImGui.Spacing()
        end

        ImGui.BeginChild("WindowChild")

        int $tab = ImGui.Tabs("TabBar", "Checkbox,Button,Input,Text,Styles")

        if $tab == 0
        then
            ImGui.Spacing()
            ImGui.Columns(2)
            $gVersionInfo = ImGui.Checkbox("Show version info", $gVersionInfo)
            ImGui.NextColumn()
            $gTimerExample = ImGui.Checkbox("Show timer example", $gTimerExample)
            ImGui.Columns(1)
            ImGui.Spacing()
        end


        if $tab == 1
        then
            ImGui.Spacing()
            if ImGui.CollapsingHeader("Arrow buttons")
            then
                ImGui.ButtonArrow("Left", 0)
                ImGui.SameLine()
                ImGui.ButtonArrow("Right", 1)
                ImGui.SameLine()
                ImGui.ButtonArrow("Up", 2)
                ImGui.SameLine()
                ImGui.ButtonArrow("Down", 3)

                ImGui.Separator()
                ImGui.Spacing()
            end
            
            if ImGui.CollapsingHeader("Radio buttons")
            then
                $gRadioBtn = ImGui.RadioButton("RB1", $gRadioBtn, 1)
                ImGui.SameLine()
                $gRadioBtn = ImGui.RadioButton("RB2", $gRadioBtn, 2)
                ImGui.SameLine()
                $gRadioBtn = ImGui.RadioButton("RB3", $gRadioBtn, 3)
                ImGui.Spacing()
            end

            if ImGui.CollapsingHeader("Regular buttons")
            then
                ImGui.GetScalingSize("S0", 2, 0, $szX, $szY)
                if ImGui.Button("Normal button", $szX, $szY)
                then
                    Text.PrintString("Normal button was pressed", 1000)
                end
                ImGui.SameLine()
                if ImGui.ButtonImage("Image Button", $gImage, $szX, $szY)
                then
                    Text.PrintString("Image Button was pressed", 1000)
                end

                ImGui.Spacing()

                float $szX = 0
                float $szY = 0
                $szX, $szY = ImGui.GetScalingSize("S1", 3, 0)
                if ImGui.ButtonColored("CB 1", 1.0, 0.0, 0.0, 1.0, $szX, $szY)
                then
                    Text.PrintString("Color button 1 was pressed", 1000)
                end
                ImGui.SameLine()
                if ImGui.ButtonColored("CB 2", 0.0, 1.0, 0.0, 1.0, $szX, $szY)
                then
                    Text.PrintString("Color button 2 was pressed", 1000)
                end
                ImGui.SameLine()
                if ImGui.ButtonColored("CB 3", 0.0, 0.0, 1.0, 1.0, $szX, $szY)
                then
                    Text.PrintString("Color button 3 was pressed", 1000)
                end

                ImGui.GetScalingSize("S2", 1, 0, $szX, $szY)
                ImGui.Text("Tip:\n\tClick the below area")
                if ImGui.ButtonInvisible("Invis button", $szX, $szY)
                then
                    Text.PrintString("Invisible button was pressed", 1000)
                end

                if ImGui.IsItemHovered("HOver")
                then
                    ImGui.Text("Hovering invisible button")
                end

                ImGui.Spacing()
                ImGui.Separator()
            end
        end

        ImGui.Spacing()

        // Input and Slider example
        if $tab == 2
        then
            ImGui.Spacing()
            1@ = ImGui.InputInt("Int input", 420, 0, 1000)
            1@ = ImGui.InputFloat("Float input", 69.9, 0.0, 100.0)
            ImGui.Spacing()
            1@ = ImGui.SliderInt("Int slider", 5, 0, 10)
            1@ = ImGui.SliderFloat("Float slider", 5.0, 0.0, 10.0)
            ImGui.Spacing()
            s$text = ImGui.InputText("Text input widget")
            ImGui.Spacing()

            float $szX = 0
            float $szY = 0
            $szX, $szY = ImGui.GetScalingSize("S012", 2, 0)
            if ImGui.Button("Rest Inputs", $szX, $szY)
            then
                ImGui.SetItemValueInt("Int input", 420)
                ImGui.SetItemValueInt("Int slider", 5)
            end
            ImGui.SameLine()
            if ImGui.Button("Rest Sliders", $szX, $szY)
            then
                ImGui.SetItemValueFloat("Float input", 69.9)
                ImGui.SetItemValueFloat("Float slider", 5.0)
            end

            ImGui.Dummy(0.0, 20.0)
            
            float $r = 0
            float $g = 0
            float $b = 0
            float $a = 0
            $r, $g, $b, $a = ImGui.ColorPicker("Color Picker")
            ImGui.ButtonColored("COLORBTN", $r, $g, $b, $a, 70.0, 30.0)

            ImGui.Dummy(0.0, 10.0)
            ImGui.Text("Text input: " + text)

            $gComboSelection = ImGui.ComboBox("Combo", "Option1,Option2,Option3", $gComboSelection)
        end

        if $tab == 3
        then
            ImGui.Spacing()
            ImGui.Text("A little brown fox jumps over the lazy dog")
            ImGui.TextDisabled("A little brown fox jumps over the lazy dog")
            ImGui.TextColored("A little brown fox jumps over the lazy dog", 1.0, 0.0, 0.0, 1.0)
            ImGui.TextWithBullet("A little brown fox jumps over the lazy dog")
            ImGui.Spacing()
            ImGui.TextWrapped("A little brown fox jumps over the lazy dog. A little brown fox jumps over the lazy dog. A little brown fox jumps over the lazy dog")
        end

        if $tab == 4
        then
            ImGui.Spacing()
            ImGui.Text("Red checkbox")
            ImGui.Spacing()
            ImGui.PushStyleColor(ImGuiCol.FrameBg, 200, 0, 0, 255)
            ImGui.PushStyleColor(ImGuiCol.FrameBgActive, 90, 0, 0, 255)
            ImGui.PushStyleColor(ImGuiCol.FrameBgHovered, 120, 0, 0, 255)
            $gVersionInfo = ImGui.Checkbox("Show version info", $gVersionInfo)
            ImGui.PopStyleColor(3)
            ImGui.Spacing()
            ImGui.Text("Button with custom style")
            ImGui.Spacing()

            ImGui.PushStyleVar(ImGuiStyleVar.FrameRounding, 10.0)

            float $szX = 0
            float $szY = 0
            $szX, $szY = ImGui.GetScalingSize("S012", 2, 0)
            if ImGui.Button("Rounded button", $szX, $szY)
            then
                Text.PrintString("Rounded button was pressed", 1000)
            end
            ImGui.PopStyleVar(1)

            ImGui.SameLine()
            if ImGui.Button("Regular button", $szX, $szY)
            then
                Text.PrintString("Regular button was pressed", 1000)
            end
        end

        ImGui.EndChild()

        ImGui.End()
    end
    ImGui.EndFrame()


    // Timer example
    // This code has 5 second delay
    float $delta = TIMERA - $gPrevTimer
    if and
        $gTimerExample > 0
        $delta > 5000
    then
        Text.PrintString("Timer test message", 1000)
        $gPrevTimer = TIMERA
    end

    if Pad.IsKeyPressed(TOGGLE_KEY)
    then
        while Pad.IsKeyPressed(TOGGLE_KEY)
            wait 0
        end
        
        if $gShowWindow == 1
        then
           $gShowWindow = 0
        else
            $gShowWindow = 1
        end
    end
end



  __SBFTR 